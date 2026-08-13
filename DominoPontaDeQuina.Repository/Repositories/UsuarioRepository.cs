using DominoPontaDeQuina.Domain.Entities;
using DominoPontaDeQuina.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DominoPontaDeQuina.Repository.Repositories;

public class UsuarioRepository
{
    private readonly DominoDbContext _context;

    public UsuarioRepository(DominoDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorIdAsync(Guid id, bool incluirJogadores = true)
    {
        var query = _context.Usuarios.AsQueryable();
        if (incluirJogadores)
            query = query.Include(u => u.Jogadores);

        return await query.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email, bool incluirJogadores = true)
    {
        var query = _context.Usuarios.AsQueryable();
        if (incluirJogadores)
            query = query.Include(u => u.Jogadores);

        return await query.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<Usuario>> ObterTodosAsync(bool incluirJogadores = true)
    {
        var query = _context.Usuarios.AsQueryable();
        if (incluirJogadores)
            query = query.Include(u => u.Jogadores);

        return await query.ToListAsync();
    }

    public async Task<Usuario> AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> AtualizarAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> ExcluirAsync(Guid id)
    {
        var usuario = await ObterPorIdAsync(id, false);
        if (usuario is null)
            return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExisteEmailAsync(string email)
    {
        return await _context.Usuarios.AnyAsync(u => u.Email == email);
    }

    public async Task<Jogador> AdicionarJogadorAsync(Guid usuarioId, string nomeExibicao)
    {
        var usuario = await ObterPorIdAsync(usuarioId, false);
        if (usuario is null)
            throw new Exception($"Usuário com ID {usuarioId} não encontrado");

        var jogador = new Jogador
        {
            NomeExibicao = nomeExibicao,
            UsuarioId = usuarioId
        };

        await _context.Jogadores.AddAsync(jogador);
        await _context.SaveChangesAsync();
        return jogador;
    }

    public async Task<List<Jogador>> ObterJogadoresPorUsuarioAsync(Guid usuarioId)
    {
        return await _context.Jogadores
            .Where(j => j.UsuarioId == usuarioId)
            .ToListAsync();
    }
}