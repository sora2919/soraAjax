using Microsoft.AspNetCore.Mvc;

namespace soraAjax.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello Ajax!");//Content是純文字
        }
    }
}
