using System.Text;

namespace GCLab;

static class ConcatWork
{
    public static string Bad()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < 50_000; i++)
            sb.Append(i);
        return sb.ToString();
    }
    
    // Método para demonstrar o problema original (se quiser comparar)
    public static string ReallyBad()
    {
        string s = string.Empty;
        for (int i = 0; i < 50_000; i++)
            s += i;
        return s;
    }
}