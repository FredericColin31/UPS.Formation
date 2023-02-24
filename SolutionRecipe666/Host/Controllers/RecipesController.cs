using DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Host.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet("")]
        public List<Recipe>? GetRecipes()
        {
            return Factory.Instance?.GetAll();
        }
    }
}
