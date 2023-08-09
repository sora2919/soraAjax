using Microsoft.AspNetCore.Mvc;
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


            string filePath = Path.Combine(_host.WebRootPath, "Uploads", file.FileName);//用Path.Combine來結合完整路徑 IWebHostEnvironment的WebRootPath可以抓到根目錄路徑 IFormFile的FileName可以抓到檔案名稱


            //上傳檔案到uploads資料夾中
            using (var fileStream = new FileStream(filePath, FileMode.Create))//使用FileStream將圖片傳到實體路徑
            {
                file.CopyTo(fileStream);
            }

            //將圖片轉為二進位
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }

            //return Content($"上傳檔案到 {filePath}");
            member.FileName = file.FileName;
            member.FileData= imgByte;
            _context.Members.Add(member);
            _context.SaveChanges();

            return Content("新增成功!!");
        }

        public IActionResult CheckName(string name)//HW3 確認是否有重複名字
        {
            var hasName=_context.Members.FirstOrDefault(n=>n.Name == name);

            if (hasName != null) { return Content("true"); }
            else { return Content("false"); }
        }

        public IActionResult GetImageByte(int id=1) 
        {
            Members? member = _context.Members.Find(id);//Find可以找PK
            byte[]? img = member.FileData;
            return File(img, "image/jpeg");//這邊可以自動轉換類型，第二個參數的意思是要轉成圖片/檔案格式
        }

        //讀取資料庫中的縣市資料
        public IActionResult Cities()
        {
            var cities=_context.Address.Select(c=>c.City).Distinct();
            //var cities = _context.Address.Select(c => new {c.City}).Distinct(); 這個會連同欄位名稱一起回傳 但現在只要讀取簡單的城市名稱就好所以用上面的
            return Json(cities);
        }

        //由縣市去抓取對應的鄉鎮區資料
        public IActionResult Districts(string city)
        {
            var districts = _context.Address.Where(d => d.City== city).Select(c=>c.SiteId).Distinct();
            return Json(districts);
        }

        //由鄉鎮區去抓路名資料

        public IActionResult Roads(string siteId)
        {
            var roads = _context.Address.Where(a => a.SiteId == siteId).Select(c => c.Road).Distinct();
            return Json(roads);
        }

    }
}
