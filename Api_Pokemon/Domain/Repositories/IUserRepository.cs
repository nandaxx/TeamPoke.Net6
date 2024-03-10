using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task <ICollection<User>> FindAll ();
        Task<User> FindByName (string name);
        Task<User> FindById (int id);
        Task<User> Create (User user);
    }
}
