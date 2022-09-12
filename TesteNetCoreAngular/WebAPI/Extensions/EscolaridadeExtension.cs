using Data.Entities;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    public static class EscolaridadeExtension
    {
        public static EscolaridadeModel ToEscolaridadeModel(this Escolaridade escolaridade)
        {
            return new EscolaridadeModel
            {
                Id = escolaridade.Id,
                Descricao = escolaridade.Descricao
            };
        }

        public static IEnumerable<EscolaridadeModel> ToEscolaridadeModelList(this IEnumerable<Escolaridade> escolaridades)
        {
            List<EscolaridadeModel> escolaridadeModels = new List<EscolaridadeModel>();

            foreach (var escolaridade in escolaridades)
            {
                escolaridadeModels.Add(escolaridade.ToEscolaridadeModel());
            }

            return escolaridadeModels;
        }
    }
}
