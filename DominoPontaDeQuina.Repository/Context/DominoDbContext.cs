using DominoPontaDeQuina.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DominoPontaDeQuina.Repository.Context;

public class DominoDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Jogador> Jogadores { get; set; }
    public DbSet<Jogo> Jogos { get; set; }
    public DbSet<ParticipacaoJogo> ParticipacoesJogo { get; set; }

    public DominoDbContext() { }

    public DominoDbContext(DbContextOptions<DominoDbContext> options) 
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Data Source=domino.db";
            optionsBuilder.UseSqlite(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CONFIGURAÇÃO DO USUARIO VIA FLUENT API
        ConfigureUsuario(modelBuilder);

        // Configurações adicionais (Jogador já está com Data Annotations)
        ConfigureJogador(modelBuilder);
        ConfigureJogo(modelBuilder);
        ConfigureParticipacaoJogo(modelBuilder);
    }

    /// <summary>
    /// Configuração da entidade Usuario usando FLUENT API
    /// </summary>
    private void ConfigureUsuario(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            // Nome da tabela
            entity.ToTable("Usuarios");

            // Chave primária
            entity.HasKey(u => u.Id);

            // Propriedades
            entity.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome");

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Email");

            // Índice único para email
            entity.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_Usuarios_Email");

            entity.Property(u => u.HashSenha)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("HashSenha");

            entity.Property(u => u.CriadoEm)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("CriadoEm");

            // Relacionamento: Usuario -> Jogadores (1:N)
            entity.HasMany(u => u.Jogadores)
                .WithOne(j => j.Usuario)
                .HasForeignKey(j => j.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private void ConfigureJogador(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jogador>(entity =>
        {
            // Jogador já está configurado com Data Annotations
            // Apenas configuramos índices adicionais
            entity.HasIndex(j => j.UsuarioId)
                .HasDatabaseName("IX_Jogadores_UsuarioId");
        });
    }

    private void ConfigureJogo(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jogo>(entity =>
        {
            // Jogo configurado por convenções
            // Apenas índices adicionais
            entity.HasIndex(j => j.Status)
                .HasDatabaseName("IX_Jogos_Status");

            entity.HasIndex(j => j.IniciadoEm)
                .HasDatabaseName("IX_Jogos_IniciadoEm");
        });
    }

    private void ConfigureParticipacaoJogo(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParticipacaoJogo>(entity =>
        {
            // Índices para consultas frequentes
            entity.HasIndex(p => new { p.JogoId, p.JogadorId })
                .IsUnique()
                .HasDatabaseName("IX_ParticipacoesJogo_JogoId_JogadorId");

            entity.HasIndex(p => p.JogoId)
                .HasDatabaseName("IX_ParticipacoesJogo_JogoId");

            entity.HasIndex(p => p.JogadorId)
                .HasDatabaseName("IX_ParticipacoesJogo_JogadorId");
        });
    }
}