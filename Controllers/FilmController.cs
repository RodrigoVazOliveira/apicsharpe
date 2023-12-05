using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace filmesApi;

[ApiController]
[Route("/films")]
public class FilmController : ControllerBase
{
    private readonly ILogger<FilmController> _logger;
    private static readonly List<Film> films = new List<Film>();
    private static int id = 0;

    public FilmController(ILogger<FilmController> logger) 
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Add([FromBody] Film film)
    {
        Film filmWithId = new Film(id++, film.Title, film.Gender, film.Duration);
        _logger.LogInformation("Add new film");
        films.Add(filmWithId);
        _logger.LogInformation("todos os filmes " + films);

        return Created(new Uri($"https://localhost:7037/films/{filmWithId.Id}"),  filmWithId);
    }

    [HttpGet]
    public IEnumerable<Film> GetAll([FromQuery] int skip, [FromQuery] int take) 
    {
        _logger.LogInformation("get all films");

        return films.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult getById(int id)
    {
        _logger.LogInformation("get film by id " + id);

        Film? film = films.FirstOrDefault(film => film.Id == id);

        if (film == null)
        {
            _logger.LogWarning("not found film");

            return NotFound();
        }

        _logger.LogInformation("film found");

        return Ok(film);
    }
}
