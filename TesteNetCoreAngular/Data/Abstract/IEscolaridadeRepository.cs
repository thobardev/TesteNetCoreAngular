using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IEscolaridadeRepository
    {
        Escolaridade Get(int id);
        IEnumerable<Escolaridade> GetAll();
    }
}
