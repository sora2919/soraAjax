using Microsoft.AspNetCore.Mvc;

namespace soraAjax.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000); //睡5秒鐘，再往下執行
            return Content("Hello Ajax!");//Content是純文字
        }
    }
}
