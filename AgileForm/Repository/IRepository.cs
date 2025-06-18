using AgileForm.Models;

namespace AgileForm.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Save();
    }
}
