using DominoPontaDeQuina.Domain.Entities;
using DominoPontaDeQuina.Repository.Context;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("=== DOMINO PONTA DE QUINA - HANDS ON AULA 14 ===\n");

var optionsBuilder = new DbContextOptionsBuilder<DominoDbContext>()
    .UseSqlite("Data Source=domino.db");

using var context = new DominoDbContext(optionsBuilder.Options);

// 1. Verificar banco
Console.WriteLine("--- Verificando Banco de Dados ---");
var existe = await context.Database.CanConnectAsync();
Console.WriteLine($"✓ Banco existe: {existe}");

if (!existe)
{
    Console.WriteLine("✗ Banco de dados não encontrado!");
    return;
}

// 2. Verificar migrações
var migrations = await context.Database.GetAppliedMigrationsAsync();
Console.WriteLine($"✓ Migrações aplicadas: {string.Join(", ", migrations)}");

// 3. Executar Seed
Console.WriteLine("\n--- Executando Seed ---");
await SeedData.InicializarAsync(context);

// 4. Listar dados
Console.WriteLine("\n--- Dados no Banco ---");

// Usuários
var usuarios = await context.Usuarios
    .Include(u => u.Jogadores)
    .ToListAsync();

Console.WriteLine($"\n📋 Usuários ({usuarios.Count}):");
foreach (var u in usuarios)
{
    Console.WriteLine($"  - {u.Nome} ({u.Email})");
    foreach (var j in u.Jogadores)
    {
        Console.WriteLine($"    * Jogador: {j.NomeExibicao} (ID: {j.Id})");
    }
}

// Jogos
var jogos = await context.Jogos
    .Include(j => j.Participacoes)
        .ThenInclude(p => p.Jogador)
    .ToListAsync();

Console.WriteLine($"\n📋 Jogos ({jogos.Count}):");
foreach (var jogo in jogos)
{
    Console.WriteLine($"  - Jogo ID: {jogo.Id} | Status: {jogo.Status} | Iniciado: {jogo.IniciadoEm:dd/MM/yyyy HH:mm}");
    foreach (var p in jogo.Participacoes)
    {
        Console.WriteLine($"    * {p.Jogador?.NomeExibicao ?? "N/A"} - Posição: {p.Posicao} | Pontos: {p.Pontuacao} | Vencedor: {(p.Vencedor ? "Sim" : "Não")}");
    }
}

Console.WriteLine("\nVerificação concluída com sucesso!");
Console.WriteLine("\n📋 RESUMO DO HANDS ON:");
Console.WriteLine("   Usuario configurado com Fluent API");
Console.WriteLine("   Jogador configurado com Data Annotations");
Console.WriteLine("   Jogo configurado por convenções");
Console.WriteLine("   DominoDbContext com DbSets necessários");
Console.WriteLine("   Conexão SQLite configurada");
Console.WriteLine("   Migration aplicada ao banco");