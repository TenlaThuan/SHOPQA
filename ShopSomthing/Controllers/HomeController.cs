using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShopSomthing.Models;

namespace ShopSomthing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("User/Index");
        }
        public IActionResult About()
        {
            return View("User/About");
        }
        public IActionResult Nam()
        {
            return View();
        }

        public IActionResult Nu()
        {
            return View("User/Nu");
        }

        public IActionResult TreEm()
        {
            return View("User/TreEm");
        }
        public IActionResult DangNhap()
        {
            return View("User/DangNhap");
        }
        public IActionResult DangKy()
        {
            return View("User/DangKy");
        }
        public IActionResult GioHang()
        {
            return View("User/GioHang");
        }
        public IActionResult ChiTietSanPham()
        {
            return View("User/ChiTietSanPham");
        }
        public IActionResult Admin()
        {
            return View("Admin/Admin");
        }
        public IActionResult QLTK()
        {
            return View("Admin/QLTK");
        }
        public IActionResult ThongKe()
        {
            return View("Admin/ThongKe");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
