using Data.Abstract;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EscolaridadeRepository: IEscolaridadeRepository
    {
        DataContext context;
        public EscolaridadeRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task<Escolaridade> GetAsync(int id)
        {
            try
            {
                var escolaridade = await context.Escolaridades.Where(e => e.Id == id).FirstOrDefaultAsync();

                if (escolaridade != null)
                    return escolaridade;
                else
                    throw new Exception("Escolaridade não encontrada.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Escolaridade>> GetAllAsync()
        {
            try
            {
                var escolaridades = await context.Escolaridades.ToListAsync();

                return escolaridades;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
