using DominoPontaDeQuina.Domain.Entities;
using DominoPontaDeQuina.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DominoPontaDeQuina.Migrations;

public static class SeedData
{
    public static async Task InicializarAsync(DominoDbContext context)
    {
        // Verificar se já existem dados
        if (await context.Usuarios.AnyAsync())
        {
            Console.WriteLine("Dados já existentes. Pulando seed.");
            return;
        }

        Console.WriteLine("Inserindo dados iniciais...");

        // Criar usuários
        var usuarios = new[]
        {
            new Usuario 
            { 
                Nome = "João Silva", 
                Email = "joao@email.com", 
                HashSenha = "hash_joao_123" 
            },
            new Usuario 
            { 
                Nome = "Maria Oliveira", 
                Email = "maria@email.com", 
                HashSenha = "hash_maria_456" 
            },
            new Usuario 
            { 
                Nome = "Pedro Santos", 
                Email = "pedro@email.com", 
                HashSenha = "hash_pedro_789" 
            }
        };

        await context.Usuarios.AddRangeAsync(usuarios);
        await context.SaveChangesAsync();

        // Criar jogadores para os usuários
        var jogadores = new[]
        {
            new Jogador { NomeExibicao = "Joãozinho", UsuarioId = usuarios[0].Id },
            new Jogador { NomeExibicao = "Joãozinho2", UsuarioId = usuarios[0].Id },
            new Jogador { NomeExibicao = "Mariazinha", UsuarioId = usuarios[1].Id },
            new Jogador { NomeExibicao = "Pedrinho", UsuarioId = usuarios[2].Id }
        };

        await context.Jogadores.AddRangeAsync(jogadores);
        await context.SaveChangesAsync();

        Console.WriteLine($"✓ {usuarios.Length} usuários criados");
        Console.WriteLine($"✓ {jogadores.Length} jogadores criados");

        // Criar um jogo de exemplo
        var jogo = new Jogo
        {
            IniciadoEm = DateTime.UtcNow,
            Status = StatusJogo.EmAndamento
        };

        await context.Jogos.AddAsync(jogo);
        await context.SaveChangesAsync();

        // Criar participações no jogo
        var participacoes = new[]
        {
            new ParticipacaoJogo 
            { 
                JogoId = jogo.Id, 
                JogadorId = jogadores[0].Id, 
                Posicao = 1, 
                Pontuacao = 0, 
                Vencedor = false 
            },
            new ParticipacaoJogo 
            { 
                JogoId = jogo.Id, 
                JogadorId = jogadores[1].Id, 
                Posicao = 2, 
                Pontuacao = 0, 
                Vencedor = false 
            },
            new ParticipacaoJogo 
            { 
                JogoId = jogo.Id, 
                JogadorId = jogadores[2].Id, 
                Posicao = 3, 
                Pontuacao = 0, 
                Vencedor = false 
            },
            new ParticipacaoJogo 
            { 
                JogoId = jogo.Id, 
                JogadorId = jogadores[3].Id, 
                Posicao = 4, 
                Pontuacao = 0, 
                Vencedor = false 
            }
        };

        await context.ParticipacoesJogo.AddRangeAsync(participacoes);
        await context.SaveChangesAsync();

        Console.WriteLine($"✓ Jogo criado com {participacoes.Length} participantes");
        Console.WriteLine("Seed concluído com sucesso!");
    }
}