using Microsoft.AspNetCore.Mvc;
namespace WindowsFormApi.Controllers
{
    public class CheckAllsController : Controller
    {
        public async Task<object> Check()
        {
            var category = await new CategoriesController().GetCategoriesData();
            var retailer = await new RetailersController().GetRetailsData(5);
            var register = new RegistersController().RgisterDataGet();
            var login = new LoginsController().LoginDataGet();
            
            object[] arr = new object[4] { category, retailer, register, login };

            if (arr.Length > 0)
            {
                foreach (var item in arr)
                {
                    return item;
                }
            }
                return NotFound();
            
        }



        }
}
