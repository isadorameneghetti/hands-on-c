namespace Jokempo.Lib;

// Classe principal que gerencia o jogo
public class Jogo
{
    // Lista privada de todos os jogadores que já jogaram
    private readonly List<Jogador> _jogadores = new();

    // Jogador atual (pode ser nulo se nenhum foi selecionado)
    public Jogador? JogadorAtual { get; private set; }
    
    // Exposição somente leitura da lista de jogadores (encapsulamento)
    public IReadOnlyList<Jogador> Jogadores => _jogadores.AsReadOnly();

    // Método para trocar ou criar um jogador
    public Jogador TrocarJogador(string nome)
    {
        // Busca se já existe um jogador com esse nome (ignorando maiúsculas/minúsculas)
        var jogadorExistente = _jogadores.FirstOrDefault(j =>
            j.Nome.Equals(nome.Trim(), StringComparison.OrdinalIgnoreCase));

        // Se encontrou, define como atual e retorna
        if (jogadorExistente != null)
        {
            JogadorAtual = jogadorExistente;
            return jogadorExistente;
        }

        // Se não encontrou, cria um novo jogador
        var novoJogador = new Jogador(nome);
        _jogadores.Add(novoJogador);  // Adiciona na lista
        JogadorAtual = novoJogador;    // Define como atual
        return novoJogador;
    }

    // Método para jogar uma rodada
    public Rodada Jogar(Jogada jogada)
    {
        // Valida se há um jogador selecionado
        if (JogadorAtual == null)
            throw new InvalidOperationException("Nenhum jogador selecionado. Use TrocarJogador primeiro.");

        // Cria uma nova rodada com a jogada do jogador
        var rodada = new Rodada(jogada);
        
        // Registra o resultado nas estatísticas do jogador atual
        JogadorAtual.Estatisticas.RegistrarResultado(rodada.Resultado);
        
        return rodada;
    }
}