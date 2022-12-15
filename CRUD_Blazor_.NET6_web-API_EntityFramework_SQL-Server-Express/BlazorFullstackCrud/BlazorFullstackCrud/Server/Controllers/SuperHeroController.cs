using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullstackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<Comic> comics = new List<Comic>
        {
            new Comic { Id = 1, Name = "Marvel"},
            new Comic { Id = 2, Name = "DC"},
        };

        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero { 
                Id = 1, 
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                comics = comics[0]
            },
            new SuperHero {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                comics = comics[1]
            },
        };

        public async Task<IActionResult> GetSuperHeroes()
        {

        }
    }
}
