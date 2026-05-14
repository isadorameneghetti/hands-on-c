using System.Runtime.Serialization.Formatters.Binary;

public static class BinaryStorage
{
    public static async Task SaveMunicipiosByUfAsync(string uf, List<(Municipio m, string hash)> municipios, string outputDir)
    {
        var binaryPath = Path.Combine(outputDir, $"municipios_{uf}.bin");
        
        // Criar objeto serializável
        var data = new MunicipioBinaryData
        {
            Uf = uf,
            DataGeracao = DateTime.Now,
            Quantidade = municipios.Count,
            Municipios = municipios.Select(item => new MunicipioBinaryItem
            {
                Tom = item.m.Tom,
                Ibge = item.m.Ibge,
                NomeTom = item.m.NomeTom,
                NomeIbge = item.m.NomeIbge,
                Uf = item.m.Uf,
                Hash = item.hash
            }).ToList()
        };
        
        // Serializar para binário
        using (var fs = new FileStream(binaryPath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            await Task.Run(() => formatter.Serialize(fs, data));
        }
        
        // Também salvar versão texto dos dados binários para debug
        var txtPath = Path.Combine(outputDir, $"municipios_{uf}.txt");
        var sb = new StringBuilder();
        sb.AppendLine($"UF: {uf}");
        sb.AppendLine($"Data: {data.DataGeracao}");
        sb.AppendLine($"Quantidade: {data.Quantidade}");
        sb.AppendLine(new string('-', 50));
        
        foreach (var item in data.Municipios)
        {
            sb.AppendLine($"{item.Ibge} | {item.NomePreferido} | Hash: {item.Hash?[..16]}...");
        }
        
        await File.WriteAllTextAsync(txtPath, sb.ToString(), Encoding.UTF8);
    }
    
    public static async Task<MunicipioBinaryData?> LoadMunicipiosByUfAsync(string uf, string binaryDir)
    {
        var binaryPath = Path.Combine(binaryDir, $"municipios_{uf}.bin");
        
        if (!File.Exists(binaryPath))
            return null;
        
        using (var fs = new FileStream(binaryPath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return await Task.Run(() => formatter.Deserialize(fs) as MunicipioBinaryData);
        }
    }
}

// Classes para serialização binária
[Serializable]
public class MunicipioBinaryData
{
    public string Uf { get; set; } = "";
    public DateTime DataGeracao { get; set; }
    public int Quantidade { get; set; }
    public List<MunicipioBinaryItem> Municipios { get; set; } = new();
}

[Serializable]
public class MunicipioBinaryItem
{
    public string Tom { get; set; } = "";
    public string Ibge { get; set; } = "";
    public string NomeTom { get; set; } = "";
    public string NomeIbge { get; set; } = "";
    public string Uf { get; set; } = "";
    public string Hash { get; set; } = "";
    
    public string NomePreferido => !string.IsNullOrWhiteSpace(NomeIbge) ? NomeIbge : NomeTom;
}   