// ADOLab.Data/Models/Aluno.cs
using System;

namespace ADOLab.Data.Models;

/// <summary>
/// Classe que representa a entidade Aluno no domínio da aplicação.
/// Mapeia diretamente para a tabela Alunos no banco de dados.
/// </summary>
public class Aluno
{
    /// <summary>
    /// Identificador único do aluno (chave primária).
    /// Corresponde à coluna Id (IDENTITY) no banco de dados.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome completo do aluno.
    /// Corresponde à coluna Nome (NVARCHAR(100)) no banco.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Idade do aluno.
    /// Corresponde à coluna Idade (INT) no banco.
    /// </summary>
    public int Idade { get; set; }

    /// <summary>
    /// Email do aluno (opcional).
    /// Corresponde à coluna Email (NVARCHAR(200)) no banco.
    /// Pode ser nulo (NULL) no banco de dados.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Data em que o aluno foi matriculado.
    /// Corresponde à coluna DataMatricula (DATETIME) no banco.
    /// Valor padrão: data/hora atual (definido no construtor).
    /// </summary>
    public DateTime DataMatricula { get; set; } = DateTime.Now;
}