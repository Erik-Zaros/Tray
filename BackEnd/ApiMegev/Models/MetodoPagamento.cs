using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace megev.Models
{
    public class MetodoPagamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        private MetodoPagamento() { }

        public MetodoPagamento(string nome) 
        {
            Nome = nome;
        }
    }
}
