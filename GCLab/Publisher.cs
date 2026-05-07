namespace GCLab;

class Publisher
{
    public event Action? OnSomething;
    
    public void Raise() => OnSomething?.Invoke();
    
    // Método utilitário para limpar todos os handlers se necessário
    public void ClearSubscribers() => OnSomething = null;
}