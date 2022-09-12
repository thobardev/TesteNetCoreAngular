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
    public class UsuarioRepository : IUsuarioRepository
    {
        DataContext context;

        public UsuarioRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> GetAsync(int id)
        {
            try
            {
                var usuario = await context.Usuarios.Include(u => u.Escolaridade).Where(e => e.Id == id).FirstOrDefaultAsync();

                if (usuario != null)
                    return usuario;
                else
                    throw new Exception("Usuário não encontrado.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            try
            {
                var usuarios = await context.Usuarios.Include(u => u.Escolaridade).ToListAsync();

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var usuario = await context.Usuarios.Where(e => e.Id == id).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    context.Usuarios.Remove(usuario);
                    await context.SaveChangesAsync();
                }
                else
                    throw new Exception("Usuário não encontrado.");

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            try
            {
                var usuarioDB = await context.Usuarios.Where(e => e.Id == usuario.Id).FirstOrDefaultAsync();

                if (usuarioDB != null)
                {
                    usuarioDB.Nome = usuario.Nome;
                    usuarioDB.Sobrenome = usuario.Sobrenome;
                    usuarioDB.Email = usuario.Email;
                    usuarioDB.DataNascimento = usuario.DataNascimento;
                    usuarioDB.EscolaridadeId = usuario.EscolaridadeId;

                    await context.SaveChangesAsync();
                }
                else
                    throw new Exception("Usuário não encontrado.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(Usuario usuario)
        {
            try
            {
                var usuarioDB = new Usuario();

                usuarioDB.Nome = usuario.Nome;
                usuarioDB.Sobrenome = usuario.Sobrenome;
                usuarioDB.Email = usuario.Email;
                usuarioDB.DataNascimento = usuario.DataNascimento;
                usuarioDB.EscolaridadeId = usuario.EscolaridadeId;
                context.Usuarios.Add(usuarioDB);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
