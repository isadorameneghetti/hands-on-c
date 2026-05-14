public static class SearchEngine
{
    public static List<Municipio> SearchByUf(List<Municipio> municipios, string uf)
    {
        return municipios
            .Where(m => string.Equals(m.Uf, uf, StringComparison.OrdinalIgnoreCase))
            .OrderBy(m => m.NomePreferido)
            .ToList();
    }
    
    public static List<Municipio> SearchByName(List<Municipio> municipios, string termo)
    {
        return municipios
            .Where(m => m.NomePreferido.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                       m.NomeTom.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                       (m.NomeIbge?.Contains(termo, StringComparison.OrdinalIgnoreCase) ?? false))
            .OrderBy(m => m.Uf)
            .ThenBy(m => m.NomePreferido)
            .ToList();
    }
    
    public static Municipio? SearchByIbge(List<Municipio> municipios, string ibge)
    {
        return municipios.FirstOrDefault(m => string.Equals(m.Ibge, ibge, StringComparison.OrdinalIgnoreCase));
    }
    
    public static void DisplayResults(List<Municipio> resultados, string titulo)
    {
        Console.WriteLine($"\n{'='.PadRight(60, '=')}");
        Console.WriteLine($"📋 {titulo}");
        Console.WriteLine($"{'='.PadRight(60, '=')}");
        
        if (!resultados.Any())
        {
            Console.WriteLine("Nenhum resultado encontrado.");
            return;
        }
        
        Console.WriteLine($"Total encontrado: {resultados.Count}\n");
        
        foreach (var m in resultados.Take(50)) // Limitar exibição a 50 resultados
        {
            Console.WriteLine($"  {m.Ibge} | {m.Uf} | {m.NomePreferido}");
        }
        
        if (resultados.Count > 50)
        {
            Console.WriteLine($"\n  ... e mais {resultados.Count - 50} resultados");
        }
    }
}   