using CrudSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CrudSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Car> ListOfCars { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7139/api/");
            HttpResponseMessage response = await client.GetAsync("car");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var serializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                ListOfCars = JsonConvert.DeserializeObject<List<Car>>(responseBody, serializerSettings);
                TempData["ListOfCars"] = responseBody;
            }
            else
            {
                ListOfCars = new List<Car>();
            }
        }

        public async Task<IActionResult> OnPostGuessPrice(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7139/api/");
            HttpResponseMessage response = await client.GetAsync($"car/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var serializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                var car = JsonConvert.DeserializeObject<Car>(responseBody, serializerSettings);
            

            double guessPrice = double.Parse(Request.Form["guessPrice"]);

             

            if (car != null)
            {
                if (car.GuessPrice(guessPrice))
                {
                        TempData["SuccessMessage"] = "Great Job!!!!!";
                }
                else
                    {
                        TempData["ErrorMessage"] = "You Missed!!!!!";
                    }

                return RedirectToPage();
            }
            else
            {
                return NotFound();
            }
            }
            return NotFound();
        }

    }
}