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

        public IActionResult GetDemo(string name,int age=30)//有設定值代表如果沒有輸入的話就預設值給他
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "guest";
            }
            return Content($"Hello {name}! You're {age} years old.");
        }
    }
}
