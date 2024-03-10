using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPokemonRepository
    {
        Task<Pokemon> Create(Pokemon pokemon);
    }
}
