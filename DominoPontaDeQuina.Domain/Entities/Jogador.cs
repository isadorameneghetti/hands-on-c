using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominoPontaDeQuina.Domain.Entities;

[Table("Jogadores")]
public class Jogador
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "O nome de exibição é obrigatório")]
    [MaxLength(100, ErrorMessage = "O nome de exibição deve ter no máximo 100 caracteres")]
    [MinLength(2, ErrorMessage = "O nome de exibição deve ter no mínimo 2 caracteres")]
    [Column("NomeExibicao")]
    public string NomeExibicao { get; set; } = string.Empty;

    [Required]
    [Column("UsuarioId")]
    public Guid UsuarioId { get; set; }

    [ForeignKey(nameof(UsuarioId))]
    public Usuario Usuario { get; set; } = null!;

    [InverseProperty(nameof(ParticipacaoJogo.Jogador))]
    public ICollection<ParticipacaoJogo> Participacoes { get; set; } = new List<ParticipacaoJogo>();
}