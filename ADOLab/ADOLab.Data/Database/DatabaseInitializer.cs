// ADOLab.Data/Database/DatabaseInitializer.cs
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ADOLab.Data.Database;

/// <summary>
/// Classe estática responsável por inicializar o banco de dados.
/// Verifica e cria a tabela Alunos se ela não existir.
/// </summary>
public static class DatabaseInitializer
{
    /// <summary>
    /// Inicializa o banco de dados criando a tabela Alunos se necessário.
    /// Deve ser chamada uma vez no início da aplicação.
    /// </summary>
    /// <param name="configuration">Configuração com a connection string</param>
    public static void Initialize(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServerConnection")
            ?? throw new InvalidOperationException("Connection string não encontrada.");

        // ===== DDL (Data Definition Language) =====
        // Script para criar a tabela se ela não existir
        // Usa sysobjects (tabela de sistema do SQL Server) para verificar existência
        const string createTableSql = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Alunos' AND xtype='U')
            BEGIN
                CREATE TABLE Alunos (
                    Id INT IDENTITY(1,1) PRIMARY KEY,        -- Auto-incremento a partir de 1, incremento de 1
                    Nome NVARCHAR(100) NOT NULL,             -- Obrigatório, máximo 100 caracteres
                    Idade INT NOT NULL,                       -- Obrigatório
                    Email NVARCHAR(200) NULL,                -- Opcional (aceita NULL)
                    DataMatricula DATETIME NOT NULL DEFAULT GETDATE()  -- Valor padrão: data/hora atual
                );
            END";

        using var conn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand(createTableSql, conn);

        conn.Open();

        // ExecuteNonQuery para DDL (CREATE TABLE)
        // Não retorna dados, apenas executa o comando
        cmd.ExecuteNonQuery();

        Console.WriteLine("Banco de dados inicializado com sucesso.");
    }
}