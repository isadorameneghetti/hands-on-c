using System.Runtime.InteropServices;

namespace GCLab;

class Pinner : IDisposable
{
    private GCHandle _handle;
    private bool _disposed = false;
    private byte[] _data;
    
    public byte[] PinLongTime()
    {
        _data = new byte[256];
        _handle = GCHandle.Alloc(_data, GCHandleType.Pinned);
        return _data;
    }
    
    public void Dispose()
    {
        if (!_disposed)
        {
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
            _disposed = true;
        }
    }
    
    ~Pinner()
    {
        Dispose();
    }
}