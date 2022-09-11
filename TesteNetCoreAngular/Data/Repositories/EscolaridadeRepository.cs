using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EscolaridadeRepository
    {
        DataContext context;
        public EscolaridadeRepository(DataContext context)
        {
            this.context = context;
        }


        public Escolaridade Get(int id)
        {
            try
            {
                var escolaridade = context.Escolaridades.Where(e => e.Id == id).FirstOrDefault();

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

        public IEnumerable<Escolaridade> GetAll()
        {
            try
            {
                var escolaridades = context.Escolaridades.ToList();

                return escolaridades;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
