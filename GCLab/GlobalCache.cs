namespace GCLab;

static class GlobalCache
{
    private static readonly List<WeakReference<byte[]>> _cache = new();
    private static readonly int _maxCacheSize = 5;
    
    public static void Add(byte[] data)
    {
        // Limpar referências mortas antes de adicionar
        CleanupDeadReferences();
        
        if (_cache.Count >= _maxCacheSize)
        {
            // Remover o mais antigo (FIFO simples)
            _cache.RemoveAt(0);
        }
        
        _cache.Add(new WeakReference<byte[]>(data));
    }
    
    private static void CleanupDeadReferences()
    {
        _cache.RemoveAll(wr => !wr.TryGetTarget(out _));
    }
    
    public static int GetAliveCount()
    {
        CleanupDeadReferences();
        return _cache.Count;
    }
}