using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }

        public virtual Escolaridade Escolaridade { get; set; } = null!;
    }
}
