namespace megev.Models
{
    public class UsuarioDTO
    {
        public string Nome { get; set; } = string.Empty; 
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public decimal SaldoConta { get; set; } = 0m;
        public string UserImage { get; set; } = string.Empty; 
    }

    public class UsuarioOutputDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal SaldoConta { get; set; } = 0m;
        public string UserImage { get; set; } = string.Empty;
    }

    public class UsuarioLoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}