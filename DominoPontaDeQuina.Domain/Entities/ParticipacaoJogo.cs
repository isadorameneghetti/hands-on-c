using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominoPontaDeQuina.Domain.Entities;

[Table("ParticipacoesJogo")]
public class ParticipacaoJogo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column("JogoId")]
    public Guid JogoId { get; set; }

    [Required]
    [Column("JogadorId")]
    public Guid JogadorId { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "A posição deve ser um valor positivo")]
    [Column("Posicao")]
    public int Posicao { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "A pontuação deve ser um valor positivo")]
    [Column("Pontuacao")]
    public int Pontuacao { get; set; }

    [Required]
    [Column("Vencedor")]
    public bool Vencedor { get; set; }

    [ForeignKey(nameof(JogoId))]
    public Jogo Jogo { get; set; } = null!;

    [ForeignKey(nameof(JogadorId))]
    public Jogador Jogador { get; set; } = null!;
}