using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);

        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }

    //Retornar filmes
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    //Retornar um filme pelo id
    [HttpGet("{id}")]
    public Filme? RecuperaFilmePorId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }


}
