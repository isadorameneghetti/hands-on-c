using System;

// Permite usar emojis no console
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Dicionário que armazena estatísticas de todos os jogadores
// A chave é o nome do jogador e o valor é uma tupla com vitórias, derrotas e empates
var estatisticas = new Dictionary<string, (int vitorias, int derrotas, int empates)>();

Console.WriteLine("😀 Olá! Vamos jogar Jokempo?");
var nomeJogador = PedirNomeJogador();

// Controla se o jogo continua executando
bool jogando = true;

// Loop principal - mantém o menu ativo até o usuário sair
while (jogando)
{
    // Exibe o menu e captura a opção escolhida
    var opcao = ExibirMenu(nomeJogador);

    // Processa a opção escolhida
    switch (opcao)
    {
        case '1': // Jogar
            // Executa uma partida e guarda o resultado
            var resultado = Jogar(nomeJogador);

            // Se for um jogador novo, adiciona no dicionário
            if (!estatisticas.ContainsKey(nomeJogador))
                estatisticas[nomeJogador] = (0, 0, 0);

            // Pega as estatísticas atuais do jogador
            var stats = estatisticas[nomeJogador];
            
            // Atualiza as estatísticas conforme o resultado
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

        case '2': // Trocar Jogador
            // Solicita um novo nome
            nomeJogador = PedirNomeJogador();
            break;

        case '3': // Estatísticas
            // Mostra o desempenho de todos os jogadores
            ExibirEstatisticas(estatisticas);
            break;

        case '0': // Sair
            // Encerra o loop principal
            jogando = false;
            break;
    }
}

Console.WriteLine("\n👋 Tchau! Até a próxima!");

// --- MÉTODOS ---

// Solicita e valida o nome do jogador
string PedirNomeJogador()
{
    string nome;
    do
    {
        Console.Write("\nDigite o nome do jogador: ");
        nome = Console.ReadLine()!;

        // Verifica se o nome não está vazio
        if (string.IsNullOrWhiteSpace(nome))
            Console.WriteLine("❌ Nome inválido! O nome não pode ser vazio.");

    } while (string.IsNullOrWhiteSpace(nome)); // Repete enquanto for inválido

    nome = nome.Trim(); // Remove espaços extras
    Console.WriteLine($"Bem-vindo(a), {nome}!");
    return nome;
}

// Exibe as opções do menu e retorna a escolha do usuário
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
        
        // Lê apenas um caractere (não precisa pressionar Enter)
        opcao = Console.ReadKey().KeyChar;
        Console.WriteLine();

        // Verifica se a opção é válida
        valida = true;
        switch (opcao)
        {
            case '0':
            case '1':
            case '2':
            case '3':
                // Opções válidas
                break;
            default:
                Console.WriteLine("❌ Opção inválida! Tente novamente.");
                valida = false;
                break;
        }
    } while (!valida); // Repete enquanto a opção for inválida

    return opcao;
}

// Executa uma partida completa
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

        // Converte a tecla pressionada em número (0, 1 ou 2)
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
                jogada = -1; // Jogada inválida
                Console.WriteLine("❌ Jogada inválida! Escolha 0, 1 ou 2.");
                valida = false;
                break;
        }
    } while (!valida); // Repete enquanto a jogada for inválida

    // Gera a jogada do computador
    var jogadaPC = GerarJogadaPC();

    // Mostra a jogada do computador
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

    // Descobre quem ganhou
    var resultado = DeterminarResultado(jogada, jogadaPC);
    
    // Mostra o resultado
    ExibirResultado(resultado, nome);
    
    return resultado;
}

// Gera um número aleatório entre 0 e 2 para o computador
int GerarJogadaPC()
{
    return new Random().Next(3);
}

// Aplica as regras do Jokempo para determinar o vencedor
string DeterminarResultado(int jogador, int pc)
{
    // Se forem iguais, empatou
    if (jogador == pc)
        return "empate";

    // Verifica quem ganhou baseado nas regras
    switch (jogador)
    {
        case 0: // Pedra
            // Pedra ganha de Tesoura (2) e perde para Papel (1)
            return pc == 2 ? "vitoria" : "derrota";
        case 1: // Papel
            // Papel ganha de Pedra (0) e perde para Tesoura (2)
            return pc == 0 ? "vitoria" : "derrota";
        case 2: // Tesoura
            // Tesoura ganha de Papel (1) e perde para Pedra (0)
            return pc == 1 ? "vitoria" : "derrota";
        default:
            return "empate";
    }
}

// Exibe mensagem conforme o resultado da partida
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

// Mostra todas as estatísticas acumuladas
void ExibirEstatisticas(Dictionary<string, (int vitorias, int derrotas, int empates)> stats)
{
    // Verifica se existe alguma estatística
    if (stats.Count == 0)
    {
        Console.WriteLine("\nNenhuma partida jogada ainda.");
        return;
    }

    Console.WriteLine("\n--- Estatísticas ---");
    
    // Percorre todos os jogadores no dicionário
    foreach (var jogador in stats)
    {
        // Calcula o total de partidas do jogador
        var total = jogador.Value.vitorias + jogador.Value.derrotas + jogador.Value.empates;
        
        Console.WriteLine($"Jogador: {jogador.Key}");
        Console.WriteLine($"  Vitórias: {jogador.Value.vitorias}");
        Console.WriteLine($"  Derrotas: {jogador.Value.derrotas}");
        Console.WriteLine($"  Empates:  {jogador.Value.empates}");
        Console.WriteLine($"  Total:    {total}");
        Console.WriteLine();
    }
}