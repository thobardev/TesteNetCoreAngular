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

        public Usuario Get(int id)
        {
            try
            {
                var usuario = context.Usuarios.Include(u => u.Escolaridade).Where(e => e.Id == id).FirstOrDefault();

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

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                var usuarios = context.Usuarios.Include(u => u.Escolaridade).ToList();

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(int id)
        {
            try
            {
                var usuario = context.Usuarios.Where(e => e.Id == id).FirstOrDefault();

                if (usuario != null)
                {
                    context.Usuarios.Remove(usuario);
                    context.SaveChanges();
                }
                else
                    throw new Exception("Usuário não encontrado.");

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                var usuarioDB = context.Usuarios.Where(e => e.Id == usuario.Id).FirstOrDefault();

                if (usuarioDB != null)
                {
                    usuarioDB.Nome = usuario.Nome;
                    usuarioDB.Sobrenome = usuario.Sobrenome;
                    usuarioDB.Email = usuario.Email;
                    usuarioDB.DataNascimento = usuario.DataNascimento;
                    usuarioDB.EscolaridadeId = usuario.EscolaridadeId;

                    context.SaveChanges();
                }
                else
                    throw new Exception("Usuário não encontrado.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(Usuario usuario)
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
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
