namespace Jokempo.Lib;

// Classe que representa um jogador
public class Jogador
{
    // Propriedade somente leitura (nome não pode ser alterado após criar)
    public string Nome { get; }
    
    // Cada jogador tem suas próprias estatísticas
    public Estatisticas Estatisticas { get; }

    // Construtor - executado quando criamos um novo jogador
    public Jogador(string nome)
    {
        // Validação: nome não pode ser vazio
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do jogador não pode ser vazio.", nameof(nome));

        // Remove espaços extras e armazena o nome
        Nome = nome.Trim();
        
        // Inicializa as estatísticas do jogador
        Estatisticas = new Estatisticas();
    }
}