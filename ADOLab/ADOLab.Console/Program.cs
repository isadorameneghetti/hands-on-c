// ============================================================
// Program.cs - Aplicação Console ADO.NET
// Demonstra CRUD completo com SQL Server
// ============================================================

using ADOLab.Data.Database;
using ADOLab.Data.Models;
using ADOLab.Data.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;

// ============================================================
// CARREGAR CONFIGURAÇÃO DO appsettings.json
// ============================================================
// Lê a connection string do arquivo de configuração
// BaseDirectory aponta para a pasta onde o EXE está rodando
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// ============================================================
// INICIALIZAR O BANCO DE DADOS
// ============================================================
// Cria a tabela Alunos se não existir
DatabaseInitializer.Initialize(configuration);

// ============================================================
// INSTANCIAR O REPOSITÓRIO
// ============================================================
// Repository Pattern: encapsula toda a lógica de acesso a dados
var repository = new AlunoRepository(configuration);

// ============================================================
// INÍCIO DOS TESTES - CRUD COMPLETO
// ============================================================

Console.WriteLine("=== ADO.NET CRUD - AlunoRepository ===\n");

// ------------------------------------------------------------
// 1. CREATE (Inserir) - ExecuteScalar
// ------------------------------------------------------------
// Retorna o ID gerado pelo banco (IDENTITY)
Console.WriteLine("--- Inserindo alunos ---");
var aluno1 = new Aluno { Nome = "Ana Silva", Idade = 22, Email = "ana@email.com" };
var id1 = repository.Inserir(aluno1);
Console.WriteLine($"Aluno inserido com ID: {id1}");

var aluno2 = new Aluno { Nome = "Carlos Santos", Idade = 25, Email = "carlos@email.com" };
var id2 = repository.Inserir(aluno2);
Console.WriteLine($"Aluno inserido com ID: {id2}");

var aluno3 = new Aluno { Nome = "Mariana Oliveira", Idade = 19, Email = "mariana@email.com" };
var id3 = repository.Inserir(aluno3);
Console.WriteLine($"Aluno inserido com ID: {id3}\n");

// ------------------------------------------------------------
// 2. READ - ExecuteScalar (COUNT)
// ------------------------------------------------------------
// Retorna um único valor (total de alunos)
Console.WriteLine($"Total de alunos: {repository.ObterTotal()}\n");

// ------------------------------------------------------------
// 3. READ - SqlDataReader (Modo Conectado)
// ------------------------------------------------------------
// Conexão fica aberta durante a leitura
// Leitura forward-only, mais performática
Console.WriteLine("--- Lista de alunos (modo conectado) ---");
var todos = repository.ObterTodos();
foreach (var a in todos)
{
    Console.WriteLine($"#{a.Id} - {a.Nome} ({a.Idade} anos) - {a.Email}");
}
Console.WriteLine();

// ------------------------------------------------------------
// 4. READ - Busca com LIKE (modo conectado)
// ------------------------------------------------------------
// Usa parâmetros para prevenir SQL Injection
Console.WriteLine("--- Buscando alunos com 'ana' ---");
var busca = repository.BuscarPorNome("ana");
foreach (var a in busca)
{
    Console.WriteLine($"#{a.Id} - {a.Nome} ({a.Idade} anos)");
}
Console.WriteLine();

// ------------------------------------------------------------
// 5. READ - Obter por ID
// ------------------------------------------------------------
// Retorna null se não encontrar
Console.WriteLine("--- Obter aluno por ID ---");
var alunoBuscado = repository.ObterPorId(id1);
if (alunoBuscado != null)
{
    Console.WriteLine($"ID {alunoBuscado.Id}: {alunoBuscado.Nome} - {alunoBuscado.Email}");
}
Console.WriteLine();

// ------------------------------------------------------------
// 6. UPDATE - ExecuteNonQuery
// ------------------------------------------------------------
// Retorna o número de linhas afetadas
Console.WriteLine("--- Atualizando aluno ---");
alunoBuscado!.Idade = 23;
alunoBuscado.Email = "ana.silva@email.com";
var atualizado = repository.Atualizar(alunoBuscado);
Console.WriteLine($"Atualização bem-sucedida: {atualizado}\n");

// ------------------------------------------------------------
// 7. READ - Verificar atualização
// ------------------------------------------------------------
var alunoAtualizado = repository.ObterPorId(id1);
Console.WriteLine($"Após atualização: {alunoAtualizado?.Nome} - {alunoAtualizado?.Idade} anos - {alunoAtualizado?.Email}\n");

// ------------------------------------------------------------
// 8. READ - Modo Desconectado (DataTable)
// ------------------------------------------------------------
// Carrega dados em memória, conexão é fechada após carregar
// Permite edição offline
Console.WriteLine("--- Modo desconectado (DataTable) ---");
var dataTable = repository.ObterTodosDesconectado();
foreach (DataRow row in dataTable.Rows)
{
    Console.WriteLine($"#{row["Id"]} - {row["Nome"]} ({row["Idade"]} anos)");
}
Console.WriteLine();

// ------------------------------------------------------------
// 9. DELETE - ExecuteNonQuery
// ------------------------------------------------------------
// Retorna true se deletou, false se não encontrou
Console.WriteLine("--- Deletando aluno ---");
var deletado = repository.Deletar(id3);
Console.WriteLine($"Deleção bem-sucedida: {deletado}\n");

// ------------------------------------------------------------
// 10. READ - Total final (verificação)
// ------------------------------------------------------------
Console.WriteLine($"Total final de alunos: {repository.ObterTotal()}\n");

Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();