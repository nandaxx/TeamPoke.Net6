using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api_Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPokemonRepository _pokemonRepository;

        public TeamController(IUserRepository userRepository, IPokemonRepository pokemonRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _pokemonRepository = pokemonRepository ?? throw new ArgumentNullException(nameof(pokemonRepository));
        }


        [HttpGet("teams")]
        public async Task<ActionResult> FindAll()
        {
            var response = await _userRepository.FindAll();
            return Ok(response);
        }

        [HttpGet("teams/user")]
        public async Task<ActionResult> FindByName(string name)
        {
            var response = await _userRepository.FindByName(name);
            if (response == null) return Problem(statusCode: 404, title: "Usuário não encontrado");
            return Ok(response);
        }

        [HttpGet("teams/user/id")]
        public async Task<ActionResult> FindById(int id)
        {
            var response = await _userRepository.FindById(id);
            if (response == null) return Problem(statusCode: 404, title: "Time não encontrado");
            return Ok(response);
        }

        [HttpPost("teams")]
        public async Task<ActionResult> CreateUser(string name, [FromBody] List<string> pokemons)
        {
            if (pokemons == null || pokemons.Count == 0) return Problem(statusCode: 400, title: "A lista de pokemons não pode estar vazia.");

            var existingUser = await _userRepository.FindByName(name);
            if (existingUser != null) return Problem(statusCode: 400, title: "O nome de usuário já está em uso.");

            var userEntity = new User();
            userEntity.Name = name;

            var pokeList = new List<Pokemon>();

            foreach (var pokemon in pokemons)
            {
                string encodedName = Uri.EscapeDataString(pokemon);
                Uri url = new Uri($"https://pokeapi.co/api/v2/pokemon/{encodedName}");
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var pokemonEntity = JsonConvert.DeserializeObject<Pokemon>(result);
                        
                        pokeList.Add(pokemonEntity);
                    }
                    else
                    {
                        return Problem(statusCode: 404, title: "Nome do pokemon incorreto.");
                    }
                }
            }
            userEntity.Pokemons = pokeList;
            var entityUser = await _userRepository.Create(userEntity);
            return Ok(new { Message = "Time cadastrado com sucesso", User = entityUser });
        }
    }
}
