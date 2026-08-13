using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominoPontaDeQuina.Domain.Entities;

[Table("Usuarios")]
public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
    [Column("Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório")]
    [MaxLength(150, ErrorMessage = "O email deve ter no máximo 150 caracteres")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    [Column("Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória")]
    [MaxLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres")]
    [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
    [Column("HashSenha")]
    public string HashSenha { get; set; } = string.Empty;

    [Required]
    [Column("CriadoEm")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [InverseProperty(nameof(Jogador.Usuario))]
    public ICollection<Jogador> Jogadores { get; set; } = new List<Jogador>();
}