namespace Jokempo.Lib;

// Classe responsável por armazenar e gerenciar as estatísticas de um jogador
public class Estatisticas
{
    // Propriedades com get público e set privado (só a própria classe pode modificar)
    public int Vitorias { get; private set; }
    public int Derrotas { get; private set; }
    public int Empates { get; private set; }
    
    // Propriedade calculada (só leitura) - retorna o total de partidas
    public int Total => Vitorias + Derrotas + Empates;

    // Método para registrar o resultado de uma rodada
    public void RegistrarResultado(ResultadoRodada resultado)
    {
        // Switch para incrementar o contador correto
        switch (resultado)
        {
            case ResultadoRodada.Vitoria:
                Vitorias++;
                break;
            case ResultadoRodada.Derrota:
                Derrotas++;
                break;
            case ResultadoRodada.Empate:
                Empates++;
                break;
        }
    }
}