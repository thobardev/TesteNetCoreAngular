using Data.Entities;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    public static class UsuarioExtension
    {
        public static UsuarioModel ToUsuarioModel(this Usuario usuario)
        {
            return new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Escolaridade = usuario?.Escolaridade?.Descricao,
                EscolaridadeId = usuario.EscolaridadeId
            };
        }

        public static IEnumerable<UsuarioModel> ToUsuarioModelList(this IEnumerable<Usuario> usuarios)
        {
            List<UsuarioModel> usuarioModels = new List<UsuarioModel>();

            foreach (var usuario in usuarios)
            {
                usuarioModels.Add(usuario.ToUsuarioModel());
            }

            return usuarioModels;
        }

        public static Usuario ToUsuario(this UsuarioModel usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                DataNascimento = usuario.DataNascimento,
                Email= usuario.Email,
                EscolaridadeId = usuario.EscolaridadeId
            };
        }
    }
}
