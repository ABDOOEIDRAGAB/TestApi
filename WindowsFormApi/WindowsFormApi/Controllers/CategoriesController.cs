using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WindowsFormApi.Controllers
{
    public class CategoriesController : Controller
    {
        public class Root
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }
        public class Datum
        {
            public int categoryId { get; set; }
            public object iconUrl { get; set; }
            public string categoryName { get; set; }
            public List<object> categoryAdvertisements { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesData()
        {
            var url = "https://mobile-oman.ifin-services.com/api/Category";

            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsestring = await response.Content.ReadAsStringAsync();

                    var data = JsonSerializer.Deserialize<Root>(responsestring);

                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    return Ok(data.message);
                }

                return BadRequest();
            }

        }

    }
}
