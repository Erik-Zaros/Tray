﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace megev.Models
{
    public class Loja
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }  = string.Empty;
        public string UrlLoja { get; set; } = string.Empty;

        private Loja() { }

        public Loja(string nome, string urlLoja)
        {
            Nome = nome;
            UrlLoja = urlLoja;
        }
    }
}
