using AgileForm.Models;

namespace AgileForm.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        User GetByEmail(string email);
    }
}
