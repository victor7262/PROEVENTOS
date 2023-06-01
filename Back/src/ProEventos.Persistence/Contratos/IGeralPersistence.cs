using System.Threading.Tasks;

namespace ProEventos.Persistence.Contrato
{
    public interface IGeralPersistence
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void Deleterange<T>(T[] entityArray) where T: class;
        Task<bool> SaveChangesAsync();
    }
}