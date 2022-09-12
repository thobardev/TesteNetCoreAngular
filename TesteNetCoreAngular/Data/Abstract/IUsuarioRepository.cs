using Data.Entities;

namespace Data.Abstract
{
    public interface IUsuarioRepository
    {
        Usuario Get(int id);
        IEnumerable<Usuario> GetAll();
        void Delete(int id);
        void Update(Usuario usuario);

        void Add(Usuario usuario);

    }
}
