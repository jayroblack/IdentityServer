using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcClient.Controllers
{
    public class CallApiController : Controller
    {
        [HttpGet]
        [Route("/api/call-api")]
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:5001/identity");
            var objAs = JsonConvert.DeserializeObject<List<Pair>>(content);
            return Json(objAs);
        }
    }

    public class Pair
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}