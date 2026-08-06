// ADOLab.Data/Repositories/AlunoRepository.cs
using ADOLab.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ADOLab.Data.Repositories;

/// <summary>
/// Repositório responsável por todas as operações de banco de dados 
/// relacionadas à entidade Aluno.
/// Implementa o padrão Repository para separar a lógica de acesso a dados.
/// </summary>
public class AlunoRepository
{
    // Armazena a string de conexão obtida do appsettings.json
    private readonly string _connectionString;

    /// <summary>
    /// Construtor que recebe a configuração por injeção de dependência.
    /// </summary>
    /// <param name="configuration">Configuração da aplicação contendo as connection strings</param>
    /// <exception cref="InvalidOperationException">Lançada se a connection string não for encontrada</exception>
    public AlunoRepository(IConfiguration configuration)
    {
        // Obtém a connection string do arquivo de configuração
        // GetConnectionString procura por "ConnectionStrings:SqlServerConnection"
        _connectionString = configuration.GetConnectionString("SqlServerConnection")
            ?? throw new InvalidOperationException("Connection string não encontrada.");
    }

    // ============================================
    // OPERAÇÃO CREATE (INSERT)
    // ============================================

    /// <summary>
    /// Insere um novo aluno no banco de dados.
    /// Usa ExecuteScalar para retornar o ID gerado automaticamente.
    /// </summary>
    /// <param name="aluno">Objeto Aluno com os dados a serem inseridos</param>
    /// <returns>ID gerado pelo banco (identidade/auto-increment)</returns>
    public int Inserir(Aluno aluno)
    {
        // SQL: INSERT com parâmetros e SCOPE_IDENTITY() para pegar o último ID inserido
        // SCOPE_IDENTITY() retorna o último valor de identidade gerado no mesmo escopo
        const string sql = @"
            INSERT INTO Alunos (Nome, Idade, Email, DataMatricula) 
            VALUES (@Nome, @Idade, @Email, @DataMatricula);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        // using garante que a conexão e o comando serão fechados/dispostos corretamente
        // Isso implementa o padrão IDisposable e libera recursos automaticamente
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        // ===== PARÂMETROS =====
        // Usar parâmetros é ESSENCIAL para:
        // 1. Prevenir SQL Injection (injeção de SQL)
        // 2. Tratar automaticamente formatação de datas, strings com aspas, etc.
        // 3. Melhorar performance (o SQL Server reutiliza planos de execução)

        // SqlDbType.NVarChar: tipo para strings Unicode no SQL Server
        // Tamanho 100: mesmo tamanho definido na tabela
        cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = aluno.Nome;

        cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = aluno.Idade;

        // Email pode ser nulo: usamos DBNull.Value para representar NULL no SQL
        // Se email for null, envia DBNull.Value; senão, envia o valor
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 200)
            .Value = (object?)aluno.Email ?? DBNull.Value;

        cmd.Parameters.Add("@DataMatricula", SqlDbType.DateTime)
            .Value = aluno.DataMatricula;

        // Abre a conexão (o mais tarde possível - boa prática)
        conn.Open();

        // ExecuteScalar: executa e retorna a primeira coluna da primeira linha
        // Útil para COUNT, SUM, ou no caso, o ID gerado
        return (int)cmd.ExecuteScalar();
    }

    // ============================================
    // OPERAÇÕES READ (SELECT)
    // ============================================

    /// <summary>
    /// Obtém todos os alunos do banco de dados.
    /// Usa modo CONECTADO com SqlDataReader (leitura sequencial).
    /// </summary>
    /// <returns>Lista de todos os alunos ordenados por nome</returns>
    public List<Aluno> ObterTodos()
    {
        // SQL: SELECT básico, ordenado por nome para melhor visualização
        const string sql = "SELECT Id, Nome, Idade, Email, DataMatricula FROM Alunos ORDER BY Nome";

        var alunos = new List<Aluno>();

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        conn.Open();

        // ===== SqlDataReader =====
        // - Modo CONECTADO (conexão permanece aberta durante a leitura)
        // - Leitura apenas para frente (forward-only)
        // - Read-only (não pode modificar dados)
        // - Excelente para grandes volumes de dados
        // - Mais performático que DataSet (menos overhead de memória)
        using var reader = cmd.ExecuteReader();

        // Read() retorna true enquanto houver linhas
        // Avança o cursor para a próxima linha
        while (reader.Read())
        {
            // Cria um novo objeto Aluno para cada linha
            var aluno = new Aluno
            {
                // Acessa por índice (0, 1, 2...) - mais rápido que por nome
                // GetInt32(0): primeiro campo (Id) como INT
                Id = reader.GetInt32(0),

                // GetString(1): segundo campo (Nome) como STRING
                Nome = reader.GetString(1),

                Idade = reader.GetInt32(2),

                // IsDBNull: verifica se o valor é NULL no banco
                // Usamos o operador ternário para tratar campos anuláveis
                Email = reader.IsDBNull(3) ? null : reader.GetString(3),

                DataMatricula = reader.GetDateTime(4)
            };

            alunos.Add(aluno);
        }

        // O reader e a conexão serão fechados automaticamente ao sair do using
        return alunos;
    }

    /// <summary>
    /// Busca um aluno específico pelo seu ID.
    /// </summary>
    /// <param name="id">ID do aluno a ser buscado</param>
    /// <returns>Objeto Aluno ou null se não encontrado</returns>
    public Aluno? ObterPorId(int id)
    {
        const string sql = "SELECT Id, Nome, Idade, Email, DataMatricula FROM Alunos WHERE Id = @Id";

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        // Parâmetro para evitar SQL Injection
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        conn.Open();
        using var reader = cmd.ExecuteReader();

        // Read() retorna true se encontrou uma linha
        if (reader.Read())
        {
            return new Aluno
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Idade = reader.GetInt32(2),
                Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                DataMatricula = reader.GetDateTime(4)
            };
        }

        // Se não encontrou, retorna null
        return null;
    }

    /// <summary>
    /// Busca alunos por parte do nome (pesquisa parcial com LIKE).
    /// </summary>
    /// <param name="termo">Termo a ser pesquisado</param>
    /// <returns>Lista de alunos que contêm o termo no nome</returns>
    public List<Aluno> BuscarPorNome(string termo)
    {
        // LIKE com % no início e fim para busca parcial
        // %termo% : encontra qualquer ocorrência do termo no nome
        const string sql = @"
            SELECT Id, Nome, Idade, Email, DataMatricula 
            FROM Alunos 
            WHERE Nome LIKE @Termo 
            ORDER BY Nome";

        var alunos = new List<Aluno>();

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        // O parâmetro já inclui os % para a busca
        // Exemplo: se termo = "ana", vira "%ana%"
        cmd.Parameters.Add("@Termo", SqlDbType.NVarChar, 100).Value = $"%{termo}%";

        conn.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            alunos.Add(new Aluno
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Idade = reader.GetInt32(2),
                Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                DataMatricula = reader.GetDateTime(4)
            });
        }

        return alunos;
    }

    /// <summary>
    /// Obtém o número total de alunos cadastrados.
    /// Demonstra o uso de ExecuteScalar para consultas agregadas.
    /// </summary>
    /// <returns>Total de alunos (int)</returns>
    public int ObterTotal()
    {
        // COUNT(*) é uma função de agregação que retorna um único valor
        const string sql = "SELECT COUNT(*) FROM Alunos";

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        conn.Open();

        // ExecuteScalar: retorna um objeto (object) que precisa ser convertido
        // COUNT(*) retorna sempre um INT, então podemos fazer cast direto
        return (int)cmd.ExecuteScalar();
    }

    // ============================================
    // OPERAÇÃO UPDATE
    // ============================================

    /// <summary>
    /// Atualiza os dados de um aluno existente.
    /// </summary>
    /// <param name="aluno">Objeto com os dados atualizados (Id deve ser válido)</param>
    /// <returns>True se atualizou com sucesso, False se não encontrou</returns>
    public bool Atualizar(Aluno aluno)
    {
        const string sql = @"
            UPDATE Alunos 
            SET Nome = @Nome, Idade = @Idade, Email = @Email 
            WHERE Id = @Id";

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        // Parâmetros: mesmo padrão dos INSERTs
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = aluno.Id;
        cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = aluno.Nome;
        cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = aluno.Idade;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 200)
            .Value = (object?)aluno.Email ?? DBNull.Value;

        conn.Open();

        // ===== ExecuteNonQuery =====
        // Usado para comandos que NÃO retornam dados (INSERT, UPDATE, DELETE, DDL)
        // Retorna o número de linhas afetadas pelo comando
        int linhasAfetadas = cmd.ExecuteNonQuery();

        // Se linhasAfetadas > 0, encontrou e atualizou
        // Se 0, o registro com o Id informado não existe
        return linhasAfetadas > 0;
    }

    // ============================================
    // OPERAÇÃO DELETE
    // ============================================

    /// <summary>
    /// Remove um aluno do banco de dados pelo ID.
    /// </summary>
    /// <param name="id">ID do aluno a ser removido</param>
    /// <returns>True se removeu com sucesso, False se não encontrou</returns>
    public bool Deletar(int id)
    {
        const string sql = "DELETE FROM Alunos WHERE Id = @Id";

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);

        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        conn.Open();

        // ExecuteNonQuery retorna o número de linhas afetadas
        // Se > 0, deletou; se 0, não encontrou
        int linhasAfetadas = cmd.ExecuteNonQuery();

        return linhasAfetadas > 0;
    }

    // ============================================
    // MODO DESCONECTADO (Exemplo com DataSet)
    // ============================================

    /// <summary>
    /// Obtém todos os alunos usando o modo DESCONECTADO com DataSet.
    /// Demonstra a abordagem alternativa ao SqlDataReader.
    /// </summary>
    /// <returns>DataTable com todos os alunos</returns>
    public DataTable ObterTodosDesconectado()
    {
        const string sql = "SELECT Id, Nome, Idade, Email, DataMatricula FROM Alunos ORDER BY Nome";

        using var conn = new SqlConnection(_connectionString);

        // ===== SqlDataAdapter =====
        // - Atua como uma "ponte" entre o banco e o DataSet/DataTable
        // - Carrega TODOS os dados em memória de uma vez
        // - Fecha a conexão automaticamente após o Fill()
        // - Permite edição em memória sem conexão ativa
        var adapter = new SqlDataAdapter(sql, conn);

        // DataTable: estrutura em memória que representa uma tabela
        var dataTable = new DataTable("Alunos");

        // Fill: executa o SELECT e preenche o DataTable em memória
        // A conexão é aberta e fechada automaticamente pelo adapter
        adapter.Fill(dataTable);

        // Retorna o DataTable com os dados em memória (modo desconectado)
        return dataTable;
    }
}