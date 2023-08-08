using Microsoft.AspNetCore.Mvc;
using soraAjax.Models;

namespace soraAjax.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000); //睡5秒鐘，再往下執行
            return Content("Hello Ajax!");//Content是純文字
        }

        public IActionResult GetDemo(UserViewModel user)//改成傳viewmodel
            //GetDemo(string name,int age=30)有設定值代表如果沒有輸入的話就預設值給他30
        {
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "guest";
            }
            return Content($"Hello {user.name}! You're {user.age} years old.");
        }
    }
}
