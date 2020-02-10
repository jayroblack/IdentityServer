using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcClient.Controllers
{
    public class LogoutController : Controller
    {
        [HttpGet]
        [Route("/api/logout")]
        public IActionResult Index()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
