using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace megev.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Senha { get; set; } = string.Empty;

        public decimal SaldoConta { get; set; }

        [StringLength(255)]
        public string UserImage { get; set; } = string.Empty;

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Usuario()
        {
        }

        public Usuario(string nome, string sobrenome, string email, string senha, decimal saldoConta, string userImage)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = senha;
            SaldoConta = saldoConta;
            UserImage = userImage ?? throw new ArgumentNullException(nameof(userImage));
            Produtos = new List<Produto>();
        }
    }
}
