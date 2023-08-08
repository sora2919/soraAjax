﻿using Microsoft.AspNetCore.Mvc;
using soraAjax.Models;

namespace soraAjax.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;//注入方式建立連線
        private readonly IWebHostEnvironment _host;//注入方式來抓伺服器相關環境資訊


        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }


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

        public IActionResult Register(Members member,IFormFile file)//使用IFormFile來接收上傳的檔案，FileName檔案名稱、Length檔案大小、ContentType檔案類型
        {
            //_context.Members.Add(member);
            //_context.SaveChanges();

            string filePath = Path.Combine(_host.WebRootPath, "Uploads", file.FileName);//用Path.Combine來結合完整路徑 IWebHostEnvironment的WebRootPath可以抓到根目錄路徑 IFormFile的FileName可以抓到檔案名稱
            
            using (var fileStream = new FileStream(filePath, FileMode.Create))//使用FileStream將圖片傳到實體路徑
            {
                file.CopyTo(fileStream);
            }
            return Content($"上傳檔案到 {filePath}");

            //return Content("新增成功!!");
        }
    }
}
