using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WindowsFormApi.Controllers
{
    public class RegistersController : Controller
    {
        public class Data
        {
            public int id { get; set; }
            public object name { get; set; }
            public object username { get; set; }
            public string jwtToken { get; set; }
            public string refreshToken { get; set; }
            public UserDetails userDetails { get; set; }
        }

        public class All
        {
            public string code { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }

        public class UserDetails
        {
            public int userId { get; set; }
            public object name { get; set; }
            public string mobile { get; set; }
            public object email { get; set; }
            public object address { get; set; }
            public object dateOfBirth { get; set; }
            public object imageUrl { get; set; }
            public object gender { get; set; }
            public int unReadNotificationCount { get; set; }
        }

        public class ResponseModel
        {
            public string mobile { get; set; }
            public string pin { get; set; }
            public string fcmToken { get; set; }
        }

        [HttpPost]
        public IActionResult RgisterData()
        {
            string api = "https://mobile-oman.ifin-services.com/api/Authenticate/Register";

                using (var client = new HttpClient())
                {
                    string url = string.
                        Format(api);

                var RespobseData = new ResponseModel
                {
                    mobile = "+201151379720",
                    fcmToken = "654321",
                    pin = ""
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RespobseData),
                        Encoding.UTF8, "application/json");

                    var response = client.PostAsync(url, c).Result;

                    string responseAsString = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<All>(responseAsString);

                    return Ok(result.message);
                }
            } 
        
        [HttpGet]
        public IActionResult RgisterDataGet()
        {
            return RgisterData();
        }

    }
}
