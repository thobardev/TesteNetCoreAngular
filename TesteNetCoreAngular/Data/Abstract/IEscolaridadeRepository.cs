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
        Task<Escolaridade> GetAsync(int id);
        Task<IEnumerable<Escolaridade>> GetAllAsync();
    }
}
