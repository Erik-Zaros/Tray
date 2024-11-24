namespace megev.Models
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public CategoriaProduto Categoria { get; set; } = null!;
        public decimal? Preco { get; set; }
        public bool Status { get; set; }
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public UsuarioDto Usuario { get; set; } = null!;
    }

    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
