using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ContextDb _db;

        public PokemonRepository(ContextDb db)
        {
            _db = db;
        }
        public async Task<Pokemon> Create(Pokemon pokemon)
        {
            _db.Pokemons.Add(pokemon);
            await _db.SaveChangesAsync();
            return pokemon;
        }
    }
}
