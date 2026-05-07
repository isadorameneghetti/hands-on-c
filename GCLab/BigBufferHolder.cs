namespace GCLab;

static class BigBufferHolder
{
    public static byte[] Run()
    {        
        // Array de 85KB+ vai para LOH (85,000 é o limite)
        // Mas usando 85,001 para demonstrar
        var data = new byte[85_001];
        GlobalCache.Add(data);
        return data;
    }
}