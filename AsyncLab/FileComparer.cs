using System.Text;

public static class FileComparer
{
    public static async Task<List<string>> CompareCsvFilesAsync(string localPath, string receitaPath)
    {
        var diferencas = new List<string>();
        
        if (!File.Exists(localPath) || !File.Exists(receitaPath))
        {
            diferencas.Add("Um dos arquivos não existe para comparação");
            return diferencas;
        }
        
        var linhasLocal = await File.ReadAllLinesAsync(localPath, Encoding.UTF8);
        var linhasReceita = await File.ReadAllLinesAsync(receitaPath, Encoding.UTF8);
        
        // Comparar quantidade de registros
        if (linhasLocal.Length != linhasReceita.Length)
        {
            diferencas.Add($"Diferença na quantidade de registros: Local={linhasLocal.Length}, Receita={linhasReceita.Length}");
        }
        
        // Comparar conteúdo linha por linha
        int maxLines = Math.Max(linhasLocal.Length, linhasReceita.Length);
        
        for (int i = 0; i < maxLines; i++)
        {
            string linhaLocal = i < linhasLocal.Length ? linhasLocal[i] : "(linha ausente)";
            string linhaReceita = i < linhasReceita.Length ? linhasReceita[i] : "(linha ausente)";
            
            if (linhaLocal != linhaReceita)
            {
                // Tentar identificar qual campo foi modificado
                var localParts = linhaLocal.Split(';');
                var receitaParts = linhaReceita.Split(';');
                
                string ibgeLocal = localParts.Length > 1 ? localParts[1] : "?";
                string nomeLocal = localParts.Length > 2 ? localParts[2] : "?";
                string nomeReceita = receitaParts.Length > 2 ? receitaParts[2] : "?";
                
                diferencas.Add($"Linha {i + 1} | IBGE: {ibgeLocal} | Local: {nomeLocal} | Receita: {nomeReceita}");
            }
        }
        
        return diferencas;
    }
    
    public static async Task SaveDifferencesAsync(string outputPath, List<string> diferencas)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Data/Hora da comparação: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        sb.AppendLine("Total de diferenças: " + diferencas.Count);
        sb.AppendLine(new string('-', 80));
        
        foreach (var diff in diferencas)
        {
            sb.AppendLine(diff);
        }
        
        await File.WriteAllTextAsync(outputPath, sb.ToString(), Encoding.UTF8);
    }
}