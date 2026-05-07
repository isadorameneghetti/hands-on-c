using System.Text;

namespace GCLab;

class Logger : IDisposable
{
    private StreamWriter _writer;
    private bool _disposed = false;
    
    public Logger(string path)
    {
        _writer = new StreamWriter(path, append: true, Encoding.UTF8);
    }

    public void WriteLines(int count)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Logger));
        
        for (int i = 0; i < count; i++)
            _writer.WriteLine($"linha {i}");
        _writer.Flush();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _writer?.Dispose();
            _writer = null;
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
    
    ~Logger()
    {
        Console.WriteLine("~Logger finalizer chamado - isso não deveria acontecer se Dispose foi chamado!");
        Dispose();
    }
}