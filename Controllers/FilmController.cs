using Microsoft.AspNetCore.Mvc;

namespace filmesApi;

[ApiController]
[Route("/films")]
public class FilmController : ControllerBase
{
    private readonly ILogger<FilmController> _logger;
    private readonly List<Film> films = new List<Film>();

    public FilmController(ILogger<FilmController> logger) 
    {
        _logger = logger;
    }

    [HttpPost]
    public void addFilm([FromBody] Film film)
    {
        _logger.LogInformation("Add new film");
        films.Add(film);
        _logger.LogInformation("todos os filmes " + films);
    }
}
