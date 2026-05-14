using System.Text;

public static class DataModifier
{
    private static readonly Random _random = new Random();
    private static readonly string[] NomesModificados = new[]
    {
        " [MODIFICADO]", " [TESTE]", " [ALTERADO]", " [REVISADO]", " [ATUALIZADO]"
    };

    public static async Task ApplyRandomModificationsAsync(string filePath)
    {
        var linhas = await File.ReadAllLinesAsync(filePath, Encoding.UTF8);
        
        if (linhas.Length == 0) return;
        
        var linhasModificadas = new List<string>();
        
        // Preservar cabeçalho se existir
        int startIndex = 0;
        if (linhas[0].IndexOf("IBGE", StringComparison.OrdinalIgnoreCase) >= 0 ||
            linhas[0].IndexOf("UF", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            linhasModificadas.Add(linhas[0]);
            startIndex = 1;
        }
        
        // Modificar registros aleatórios
        for (int i = startIndex; i < linhas.Length; i++)
        {
            var linha = linhas[i];
            
            // 30% de chance de modificar o registro
            if (_random.NextDouble() < 0.3)
            {
                var parts = linha.Split(';');
                if (parts.Length >= 3)
                {
                    // Modificar o nome do município
                    var modificacao = NomesModificados[_random.Next(NomesModificados.Length)];
                    parts[2] = parts[2] + modificacao; // NomeTOM
                    if (parts.Length > 3 && !string.IsNullOrWhiteSpace(parts[3]))
                    {
                        parts[3] = parts[3] + modificacao; // NomeIBGE
                    }
                    linha = string.Join(';', parts);
                }
            }
            
            linhasModificadas.Add(linha);
        }
        
        await File.WriteAllLinesAsync(filePath, linhasModificadas, Encoding.UTF8);
    }
}