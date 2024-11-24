using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace megev.Models
{
    public class CategoriaProduto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        private CategoriaProduto() { }

        public CategoriaProduto(string nome)
        {
            Nome = nome;
        }
    }
}