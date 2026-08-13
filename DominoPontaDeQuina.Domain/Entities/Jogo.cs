using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominoPontaDeQuina.Domain.Entities;

// SEM ANOTAÇÕES - USANDO CONVENÇÕES DO EF CORE
public class Jogo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime IniciadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? FinalizadoEm { get; set; }
    public StatusJogo Status { get; set; } = StatusJogo.Aguardando;
    public ICollection<ParticipacaoJogo> Participacoes { get; set; } = new List<ParticipacaoJogo>();
}