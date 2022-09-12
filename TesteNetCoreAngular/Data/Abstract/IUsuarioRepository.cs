using Data.Entities;

namespace Data.Abstract
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(Usuario usuario);

        Task AddAsync(Usuario usuario);

    }
}
