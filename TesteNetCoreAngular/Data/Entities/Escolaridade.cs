using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Escolaridade
    {
        public Escolaridade()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
