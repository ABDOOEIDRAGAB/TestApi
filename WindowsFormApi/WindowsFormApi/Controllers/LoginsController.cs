using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WindowsFormApi.Controllers
{
    public class LoginsController : Controller
    {
        public class Son
        {
            public int id { get; set; }
            public object name { get; set; }
            public object username { get; set; }
            public string jwtToken { get; set; }
            public string refreshToken { get; set; }
            public Sister userDetails { get; set; }
        }

        public class Father
        {
            public int code { get; set; }
            public string message { get; set; }
            public Son data { get; set; }
        }

        public class Sister
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


        public class ResponseModelLogin
        {
            public string mobile { get; set; }
            public string pin { get; set; }
            public string fcmToken { get; set; }
        }

        [HttpPost]
        public IActionResult LoginData()
        {
            string api = "https://mobile-oman.ifin-services.com/api/Authenticate/Login";

            using (var client = new HttpClient())
            {
                string url = string.
                    Format(api);

                var RespobseData = new ResponseModelLogin
                {
                    mobile = "+201151379720",
                    fcmToken = "654321",
                    pin = ""
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RespobseData),
                        Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, c).Result;

                string responseAsString = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Father>(responseAsString);

                return Ok(result.message);
            }
        }

        [HttpGet]
        public IActionResult LoginDataGet()
        {
            return LoginData();
        }

    }
}
