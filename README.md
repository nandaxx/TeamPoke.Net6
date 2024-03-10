
# TeamPoke



A API permite criar times de Pokémons, usando a pokeapi.co. O usuário fornece uma lista de Pokémons, a API valida os dados e retorna uma ID única para cada time, junto com as seguintes informações dos Pokémons: o ID na Pokédex, altura e peso. Também inclui um Dockerfile e um compose para facilitar o uso em ambientes de conteiner.


## Tecnologias 

- C#/ .Net.6;
- [PokeApi](https://pokeapi.co/docs/v2);
- Docker Compose.



## Executar o Docker Compose

1 - Clonar a API;

2 - Abrir a API através do Visual Studio;

3 - Selecionar o Docker e determinar como projeto de inicalização padrão;

4 - Executar e acessar a API pelo navegandor.
## Requests
#### GET Find All

/api/Team/teams

```json
 {
    "id": 1,
    "name": "fernanda",
    "pokemons": [
      {
        "id": 133,
        "idIdentification": 10,
        "name": "eevee",
        "weight": 65,
        "height": 3
      },
      {
        "id": 4,
        "idIdentification": 11,
        "name": "charmander",
        "weight": 85,
        "height": 6
      }
    ]
  },
  {
    "id": 2,
    "name": "fernanda2",
    "pokemons": [
      {
        "id": 4,
        "idIdentification": 13,
        "name": "charmander",
        "weight": 85,
        "height": 6
      },
      {
        "id": 25,
        "idIdentification": 12,
        "name": "pikachu",
        "weight": 60,
        "height": 4
      }
    ]
  },
  {
    "id": 3,
    "name": "fernanda3",
    "pokemons": [
      {
        "id": 63,
        "idIdentification": 14,
        "name": "abra",
        "weight": 195,
        "height": 9
      },
      {
        "id": 64,
        "idIdentification": 15,
        "name": "kadabra",
        "weight": 565,
        "height": 13
      }
    ]
  }
```
#### GET By Id

/api/Team/teams/user/id

```json
{
  "id": 1,
  "name": "fernanda",
  "pokemons": [
    {
      "id": 133,
      "idIdentification": 10,
      "name": "eevee",
      "weight": 65,
      "height": 3
    },
    {
      "id": 4,
      "idIdentification": 11,
      "name": "charmander",
      "weight": 85,
      "height": 6
    }
  ]
}
```

#### GET By Name

/api/Team/teams/user
```json
{
   "id": 1,
  "name": "fernanda",
  "pokemons": [
    {
      "id": 133,
      "idIdentification": 10,
      "name": "eevee",
      "weight": 65,
      "height": 3
    },
    {
      "id": 4,
      "idIdentification": 11,
      "name": "charmander",
      "weight": 85,
      "height": 6
    }
  ]
}
```

#### POST

/api/Team/teams

```json
{
 "user": "fernanda4",
  "team": [
  "eevee",
  "ninetales",
  "doduo",
  "bayleef"
  ]
}
```
