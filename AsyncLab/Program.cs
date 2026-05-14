using System.Diagnostics;
using System.Text;
using System.Text.Json;

const int PBKDF2_ITERATIONS = 50_000;
const int HASH_BYTES = 32;
const string CSV_URL = "https://www.gov.br/receitafederal/dados/municipios.csv";
const string OUT_DIR_NAME = "mun_hash_por_uf";
const string BACKUP_DIR_NAME = "backup";

string FormatTempo(long ms)
{
    var ts = TimeSpan.FromMilliseconds(ms);
    return $"{ts.Minutes}m {ts.Seconds}s {ts.Milliseconds}ms";
}

var sw = Stopwatch.StartNew();

string baseDir = Directory.GetCurrentDirectory();
string tempCsvPath = Path.Combine(baseDir, "municipios.csv");
string backupDir = Path.Combine(baseDir, BACKUP_DIR_NAME);
string outRoot = Path.Combine(baseDir, OUT_DIR_NAME);
string binaryRoot = Path.Combine(baseDir, "binario_por_uf");
string diffPath = Path.Combine(baseDir, "diferencas_municipios.csv");

Directory.CreateDirectory(backupDir);
Directory.CreateDirectory(outRoot);
Directory.CreateDirectory(binaryRoot);

Console.WriteLine("=== ASYNCLAB - PROCESSAMENTO DE MUNICÍPIOS ===\n");

// ============================================================
// 1. VERIFICAR EXISTÊNCIA DO ARQUIVO BASE
// ============================================================
bool arquivoExiste = File.Exists(tempCsvPath);

if (arquivoExiste)
{
    Console.WriteLine("[1] Arquivo local encontrado. Fazendo backup...");
    string backupPath = Path.Combine(backupDir, $"municipios_backup_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
    File.Copy(tempCsvPath, backupPath, overwrite: true);
    Console.WriteLine($"    Backup salvo em: {backupPath}");
    
    // ============================================================
    // 2. REALIZAR ALTERAÇÕES ALEATÓRIAS NO ARQUIVO EXISTENTE
    // ============================================================
    Console.WriteLine("\n[2] Aplicando modificações aleatórias no arquivo local...");
    await DataModifier.ApplyRandomModificationsAsync(tempCsvPath);
    Console.WriteLine("    Modificações aplicadas com sucesso!");
}
else
{
    Console.WriteLine("[1] Arquivo local não encontrado. Será feito download.");
}

// ============================================================
// 3. BAIXAR NOVAMENTE O ARQUIVO DA RECEITA
// ============================================================
Console.WriteLine("\n[3] Baixando arquivo atualizado da Receita Federal...");
using (var httpClient = new HttpClient())
{
    httpClient.Timeout = TimeSpan.FromMinutes(5);
    var csvContent = await httpClient.GetStringAsync(CSV_URL);
    
    string novoCsvPath = Path.Combine(baseDir, "municipios_receita.csv");
    await File.WriteAllTextAsync(novoCsvPath, csvContent, Encoding.UTF8);
    Console.WriteLine($"    Download concluído: {novoCsvPath}");
    
    // ============================================================
    // 4. COMPARAR ARQUIVOS E SALVAR DIFERENÇAS
    // ============================================================
    Console.WriteLine("\n[4] Comparando arquivo local com o da Receita...");
    var diferencas = await FileComparer.CompareCsvFilesAsync(tempCsvPath, novoCsvPath);
    
    if (diferencas.Any())
    {
        await FileComparer.SaveDifferencesAsync(diffPath, diferencas);
        Console.WriteLine($"    Diferenças encontradas: {diferencas.Count}");
        Console.WriteLine($"    Arquivo de diferenças salvo em: {diffPath}");
        
        // Exibir primeiras 5 diferenças
        Console.WriteLine("\n    Primeiras diferenças:");
        foreach (var diff in diferencas.Take(5))
        {
            Console.WriteLine($"      {diff}");
        }
    }
    else
    {
        Console.WriteLine("    Nenhuma diferença encontrada entre os arquivos.");
    }
}

// ============================================================
// PROCESSAMENTO PRINCIPAL (PBKDF2 + HASH)
// ============================================================
Console.WriteLine("\n[5] Processando dados e gerando hashes...");
var linhas = await File.ReadAllLinesAsync(tempCsvPath, Encoding.UTF8);

int startIndex = 0;
if (linhas.Length > 0 && (linhas[0].IndexOf("IBGE", StringComparison.OrdinalIgnoreCase) >= 0 ||
    linhas[0].IndexOf("UF", StringComparison.OrdinalIgnoreCase) >= 0))
{
    startIndex = 1;
}

var municipios = new List<Municipio>();

for (int i = startIndex; i < linhas.Length; i++)
{
    var linha = (linhas[i] ?? "").Trim();
    if (string.IsNullOrWhiteSpace(linha)) continue;

    var parts = linha.Split(';');
    if (parts.Length < 5) continue;

    municipios.Add(new Municipio
    {
        Tom = Util.San(parts[0]),
        Ibge = Util.San(parts[1]),
        NomeTom = Util.San(parts[2]),
        NomeIbge = Util.San(parts[3]),
        Uf = Util.San(parts[4]).ToUpperInvariant()
    });
}

Console.WriteLine($"    Registros lidos: {municipios.Count}");

// Grupo por UF
var porUf = municipios.GroupBy(m => m.Uf)
    .Where(g => !string.Equals(g.Key, "EX", StringComparison.OrdinalIgnoreCase))
    .ToDictionary(g => g.Key, g => g.ToList());

var ufsOrdenadas = porUf.Keys.OrderBy(uf => uf).ToList();

// ============================================================
// 5. SALVAR ARQUIVOS POR UF EM FORMATO BINÁRIO
// ============================================================
Console.WriteLine("\n[6] Salvando arquivos por UF em formato binário...");

foreach (var uf in ufsOrdenadas)
{
    var listaUf = porUf[uf];
    listaUf.Sort((a, b) => string.Compare(a.NomePreferido, b.NomePreferido, StringComparison.OrdinalIgnoreCase));
    
    // Processar hashes
    var resultados = new List<(Municipio m, string hash)>();
    
    foreach (var m in listaUf)
    {
        string password = m.ToConcatenatedString();
        byte[] salt = Util.BuildSalt(m.Ibge);
        string hashHex = Util.DeriveHashHex(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);
        resultados.Add((m, hashHex));
    }
    
    // Salvar em formato binário
    await BinaryStorage.SaveMunicipiosByUfAsync(uf, resultados, binaryRoot);
    
    // Também salvar CSV e JSON (compatibilidade)
    string outPath = Path.Combine(outRoot, $"municipios_hash_{uf}.csv");
    using (var swOut = new StreamWriter(outPath, false, Encoding.UTF8))
    {
        swOut.WriteLine("TOM;IBGE;NomeTOM;NomeIBGE;UF;Hash");
        foreach (var (m, hash) in resultados)
        {
            swOut.WriteLine($"{m.Tom};{m.Ibge};{m.NomeTom};{m.NomeIbge};{m.Uf};{hash}");
        }
    }
    
    var listaJson = resultados.Select(r => new {
        r.m.Tom,
        r.m.Ibge,
        r.m.NomeTom,
        r.m.NomeIbge,
        r.m.Uf,
        Hash = r.hash
    }).ToList();
    
    string jsonPath = Path.Combine(outRoot, $"municipios_hash_{uf}.json");
    var json = JsonSerializer.Serialize(listaJson, new JsonSerializerOptions { WriteIndented = true });
    await File.WriteAllTextAsync(jsonPath, json, Encoding.UTF8);
    
    Console.WriteLine($"    UF {uf}: {resultados.Count} municípios salvos (CSV, JSON e BIN)");
}

sw.Stop();

// ============================================================
// 6. SISTEMA DE PESQUISA
// ============================================================
Console.WriteLine("\n[7] Sistema de pesquisa de municípios");
Console.WriteLine("========================================");

bool continuar = true;
while (continuar)
{
    Console.WriteLine("\nOpções de pesquisa:");
    Console.WriteLine("  1 - Pesquisar por UF");
    Console.WriteLine("  2 - Pesquisar por nome (parte do nome)");
    Console.WriteLine("  3 - Pesquisar por código IBGE");
    Console.WriteLine("  0 - Sair");
    Console.Write("\nEscolha uma opção: ");
    
    var opcao = Console.ReadLine()?.Trim();
    
    switch (opcao)
    {
        case "1":
            Console.Write("Digite a UF (ex: SP, RJ, MG): ");
            var ufBusca = Console.ReadLine()?.Trim().ToUpperInvariant();
            if (!string.IsNullOrEmpty(ufBusca))
            {
                var resultados = SearchEngine.SearchByUf(municipios, ufBusca);
                SearchEngine.DisplayResults(resultados, $"Municípios da UF {ufBusca}");
            }
            break;
            
        case "2":
            Console.Write("Digite parte do nome do município: ");
            var nomeBusca = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(nomeBusca))
            {
                var resultados = SearchEngine.SearchByName(municipios, nomeBusca);
                SearchEngine.DisplayResults(resultados, $"Municípios contendo '{nomeBusca}'");
            }
            break;
            
        case "3":
            Console.Write("Digite o código IBGE: ");
            var ibgeBusca = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(ibgeBusca))
            {
                var resultado = SearchEngine.SearchByIbge(municipios, ibgeBusca);
                if (resultado != null)
                {
                    SearchEngine.DisplayResults(new List<Municipio> { resultado }, "Município encontrado");
                }
                else
                {
                    Console.WriteLine($"Nenhum município encontrado com o código IBGE: {ibgeBusca}");
                }
            }
            break;
            
        case "0":
            continuar = false;
            Console.WriteLine("Encerrando sistema de pesquisa...");
            break;
            
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

Console.WriteLine("\n========================================");
Console.WriteLine("===== RESUMO FINAL =====");
Console.WriteLine($"UFs processadas: {ufsOrdenadas.Count}");
Console.WriteLine($"Total de municípios: {municipios.Count}");
Console.WriteLine($"Pasta de saída (CSV/JSON): {outRoot}");
Console.WriteLine($"Pasta de saída (Binário): {binaryRoot}");
Console.WriteLine($"Arquivo de diferenças: {(File.Exists(diffPath) ? diffPath : "Nenhuma diferença")}");
Console.WriteLine($"Tempo total: {FormatTempo(sw.ElapsedMilliseconds)} ({sw.Elapsed})");
Console.WriteLine("\n✅ Laboratório concluído com sucesso!");