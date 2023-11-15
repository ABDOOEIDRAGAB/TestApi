using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WindowsFormApi.Controllers
{
    public class RetailersController : Controller
    {
        public class Parent
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<Child> data { get; set; }
        }
        public class Child
        {
            public int retailerId { get; set; }
            public int retailerCode { get; set; }
            public string imageUrl { get; set; }
            public string retailerWesite { get; set; }
            public int categoryId { get; set; }
            public string retailerName { get; set; }
            public object createdBy { get; set; }
            public object creationDate { get; set; }
            public object lastModificationDate { get; set; }
            public object modifiedBy { get; set; }
            public object category { get; set; }
            public object localizations { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> GetRetailsData(int id)
        {
            var url = "https://mobile-oman.ifin-services.com/api/Retailer?categoryId="+id+"";

            ViewBag.testid = id;

            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsestring = await response.Content.ReadAsStringAsync();

                    var data = JsonSerializer.Deserialize<Parent>(responsestring);

                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    return Ok(data.message);
                }

                return BadRequest();
            }

        }

    }
}
