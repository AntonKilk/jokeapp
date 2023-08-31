using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace JokeWebApp.Controllers
{
    public class HomeController : Controller
    {
        const string apiBaseUrl = "https://v2.jokeapi.dev/joke/Any";

        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(apiBaseUrl);
                var jokeData = JObject.Parse(response);

                ViewBag.JokeCategory = jokeData["category"].Value<string>();

                if(jokeData["type"].Value<string>() == "single")
                {
                    ViewBag.Joke = jokeData["joke"].Value<string>();
                }
                else
                {
                    ViewBag.Setup = jokeData["setup"].Value<string>();
                    ViewBag.Delivery = jokeData["delivery"].Value<string>();
                }

                await httpClient.PostAsync("https://jokewebappfunction.azurewebsites.net/api/AlertFunction?code=x4kQSBGpu-1y_Umyb_Wcz3wvqP7zI_Mbzs2tSmC-PO4uAzFuQxj0_g==", new StringContent(string.Empty));

            }
            
            return View();
        }
    }
}
