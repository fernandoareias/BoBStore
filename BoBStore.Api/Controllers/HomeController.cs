
using Microsoft.AspNetCore.Mvc;

namespace BoBStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }


    }
}