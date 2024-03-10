﻿

namespace Domain.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pokemon>? Pokemons { get; set; }

        public User() { }
    }
}
