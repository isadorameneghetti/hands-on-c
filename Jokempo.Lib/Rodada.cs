namespace Jokempo.Lib;

// Classe que representa uma rodada do jogo (uma jogada)
public class Rodada
{
    // Random estático para gerar números aleatórios (compartilhado entre todas as rodadas)
    private static readonly Random _random = new();

    // Propriedades da rodada
    public Jogada JogadaJogador { get; }  // Jogada escolhida pelo jogador
    public Jogada JogadaComputador { get; } // Jogada gerada para o computador
    public ResultadoRodada Resultado { get; } // Resultado da rodada

    // Construtor - cria uma nova rodada com a jogada do jogador
    public Rodada(Jogada jogadaJogador)
    {
        JogadaJogador = jogadaJogador;
        JogadaComputador = GerarJogadaComputador(); // Gera jogada aleatória
        Resultado = DeterminarResultado(JogadaJogador, JogadaComputador); // Calcula resultado
    }

    // Método estático para gerar jogada aleatória do computador
    public static Jogada GerarJogadaComputador()
    {
        // Gera número aleatório entre 0 e 2 e converte para o enum Jogada
        return (Jogada)_random.Next(3);
    }

    // Método estático que aplica as regras do Jokempo
    public static ResultadoRodada DeterminarResultado(Jogada jogador, Jogada computador)
    {
        // Se forem iguais, empate
        if (jogador == computador)
            return ResultadoRodada.Empate;

        // Switch expression (sintaxe moderna do C#)
        return jogador switch
        {
            // Pedra ganha de Tesoura, perde para Papel
            Jogada.Pedra => computador == Jogada.Tesoura ? ResultadoRodada.Vitoria : ResultadoRodada.Derrota,
            
            // Papel ganha de Pedra, perde para Tesoura
            Jogada.Papel => computador == Jogada.Pedra ? ResultadoRodada.Vitoria : ResultadoRodada.Derrota,
            
            // Tesoura ganha de Papel, perde para Pedra
            Jogada.Tesoura => computador == Jogada.Papel ? ResultadoRodada.Vitoria : ResultadoRodada.Derrota,
            
            // Caso padrão (não deve acontecer)
            _ => ResultadoRodada.Empate
        };
    }

    // Retorna o nome da jogada com emoji para exibição
    public static string ObterNomeJogada(Jogada jogada)
    {
        return jogada switch
        {
            Jogada.Pedra => "Pedra ✊",
            Jogada.Papel => "Papel ✋",
            Jogada.Tesoura => "Tesoura ✌️",
            _ => "Desconhecida"
        };
    }

    // Retorna o nome do resultado
    public static string ObterNomeResultado(ResultadoRodada resultado)
    {
        return resultado switch
        {
            ResultadoRodada.Vitoria => "Vitória",
            ResultadoRodada.Derrota => "Derrota",
            ResultadoRodada.Empate => "Empate",
            _ => "Desconhecido"
        };
    }
}