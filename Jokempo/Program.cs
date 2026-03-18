using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var estatisticas = new Dictionary<string, (int vitorias, int derrotas, int empates)>();

Console.WriteLine("😀 Olá! Vamos jogar Jokempo?");
var nomeJogador = PedirNomeJogador();

bool jogando = true;
while (jogando)
{
    var opcao = ExibirMenu(nomeJogador);

    switch (opcao)
    {
        case '1':
            var resultado = Jogar(nomeJogador);

            if (!estatisticas.ContainsKey(nomeJogador))
                estatisticas[nomeJogador] = (0, 0, 0);

            var stats = estatisticas[nomeJogador];
            switch (resultado)
            {
                case "vitoria":
                    estatisticas[nomeJogador] = (stats.vitorias + 1, stats.derrotas, stats.empates);
                    break;
                case "derrota":
                    estatisticas[nomeJogador] = (stats.vitorias, stats.derrotas + 1, stats.empates);
                    break;
                case "empate":
                    estatisticas[nomeJogador] = (stats.vitorias, stats.derrotas, stats.empates + 1);
                    break;
            }
            break;

        case '2':
            nomeJogador = PedirNomeJogador();
            break;

        case '3':
            ExibirEstatisticas(estatisticas);
            break;

        case '0':
            jogando = false;
            break;
    }
}

Console.WriteLine("\n👋 Tchau! Até a próxima!");

// --- Métodos ---

string PedirNomeJogador()
{
    string nome;
    do
    {
        Console.Write("\nDigite o nome do jogador: ");
        nome = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(nome))
            Console.WriteLine("❌ Nome inválido! O nome não pode ser vazio.");

    } while (string.IsNullOrWhiteSpace(nome));

    nome = nome.Trim();
    Console.WriteLine($"Bem-vindo(a), {nome}!");
    return nome;
}

char ExibirMenu(string nome)
{
    char opcao;
    bool valida;

    do
    {
        Console.WriteLine($"\n--- Menu ({nome}) ---");
        Console.WriteLine("1 - Jogar");
        Console.WriteLine("2 - Trocar Jogador");
        Console.WriteLine("3 - Estatísticas");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        opcao = Console.ReadKey().KeyChar;
        Console.WriteLine();

        valida = true;
        switch (opcao)
        {
            case '0':
            case '1':
            case '2':
            case '3':
                break;
            default:
                Console.WriteLine("❌ Opção inválida! Tente novamente.");
                valida = false;
                break;
        }
    } while (!valida);

    return opcao;
}

string Jogar(string nome)
{
    int jogada;
    bool valida;

    do
    {
        Console.WriteLine("\nEscolha: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
        Console.Write($"{nome}, sua jogada: ");
        var opcao = Console.ReadKey().KeyChar;
        Console.WriteLine();

        valida = true;
        switch (opcao)
        {
            case '0':
                jogada = 0;
                Console.WriteLine($"{nome} escolheu Pedra ✊!");
                break;
            case '1':
                jogada = 1;
                Console.WriteLine($"{nome} escolheu Papel ✋!");
                break;
            case '2':
                jogada = 2;
                Console.WriteLine($"{nome} escolheu Tesoura ✌!");
                break;
            default:
                jogada = -1;
                Console.WriteLine("❌ Jogada inválida! Escolha 0, 1 ou 2.");
                valida = false;
                break;
        }
    } while (!valida);

    var jogadaPC = GerarJogadaPC();

    switch (jogadaPC)
    {
        case 0:
            Console.WriteLine("Eu escolhi Pedra ✊!");
            break;
        case 1:
            Console.WriteLine("Eu escolhi Papel ✋!");
            break;
        case 2:
            Console.WriteLine("Eu escolhi Tesoura ✌!");
            break;
    }

    var resultado = DeterminarResultado(jogada, jogadaPC);
    ExibirResultado(resultado, nome);
    return resultado;
}

int GerarJogadaPC()
{
    return new Random().Next(3);
}

string DeterminarResultado(int jogador, int pc)
{
    if (jogador == pc)
        return "empate";

    switch (jogador)
    {
        case 0:
            return pc == 2 ? "vitoria" : "derrota";
        case 1:
            return pc == 0 ? "vitoria" : "derrota";
        case 2:
            return pc == 1 ? "vitoria" : "derrota";
        default:
            return "empate";
    }
}

void ExibirResultado(string resultado, string nome)
{
    switch (resultado)
    {
        case "vitoria":
            Console.WriteLine($"\n😀 Parabéns, {nome}! Você venceu!");
            break;
        case "derrota":
            Console.WriteLine($"\n😀 Haha, eu venci! Não foi dessa vez, {nome}.");
            break;
        case "empate":
            Console.WriteLine("\n😀 Legal! Nós empatamos!");
            break;
    }
}

void ExibirEstatisticas(Dictionary<string, (int vitorias, int derrotas, int empates)> stats)
{
    if (stats.Count == 0)
    {
        Console.WriteLine("\nNenhuma partida jogada ainda.");
        return;
    }

    Console.WriteLine("\n--- Estatísticas ---");
    foreach (var jogador in stats)
    {
        var total = jogador.Value.vitorias + jogador.Value.derrotas + jogador.Value.empates;
        Console.WriteLine($"Jogador: {jogador.Key}");
        Console.WriteLine($"  Vitórias: {jogador.Value.vitorias}");
        Console.WriteLine($"  Derrotas: {jogador.Value.derrotas}");
        Console.WriteLine($"  Empates:  {jogador.Value.empates}");
        Console.WriteLine($"  Total:    {total}");
        Console.WriteLine();
    }
}
