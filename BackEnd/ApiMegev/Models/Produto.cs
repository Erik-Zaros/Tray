using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace megev.Models
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Referencia { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        public CategoriaProduto Categoria { get; set; } = null!; 

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public byte[] Image { get; set; } = Array.Empty<byte>();

        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public Produto()
        {
        }

        public Produto(string referencia, string descricao, CategoriaProduto categoria, decimal preco, bool status, byte[] image, int usuarioId)
        {
            Referencia = referencia;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
            Status = status;
            Image = image ?? throw new ArgumentNullException(nameof(image));
            UsuarioId = usuarioId;
        }
    }
}
