using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ContextDb _db;

        public UserRepository(ContextDb db)
        {
            _db = db;
        }
        public async Task<ICollection<User>> FindAll() => await _db.Users.Include(x => x.Pokemons).ToListAsync();
        public async Task<User> FindByName(string name) => await _db.Users.Include(x => x.Pokemons).SingleOrDefaultAsync(x => x.Name == name);
        public async Task<User> FindById(int id) => await _db.Users.Include(x => x.Pokemons).SingleOrDefaultAsync(x => x.Id == id);
        public async Task<User> Create(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}

