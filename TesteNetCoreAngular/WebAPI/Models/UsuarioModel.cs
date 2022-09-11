﻿namespace WebAPI.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public int EscolaridadeId { get; set; }
        public string? Escolaridade { get; set; }
    }
}
