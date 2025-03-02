using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopSomthing.Models;

namespace ShopSomthing.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Nam()
        {
            // Gọi API để lấy dữ liệu sản phẩm
            var response = await _httpClient.GetAsync("https://localhost:7116/api/SanPham"); // Đảm bảo URL API đúng

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sanPhamList = JsonConvert.DeserializeObject<List<SanPham>>(content); // Chuyển đổi dữ liệu JSON thành đối tượng

                return View(sanPhamList); // Truyền dữ liệu vào view
            }

            return View("Error"); // Nếu không thành công, trả về view lỗi
        }
        public async Task<IActionResult> Nu()
        {
            // Gọi API để lấy dữ liệu sản phẩm
            var response = await _httpClient.GetAsync("https://localhost:7116/api/SanPham"); // Đảm bảo URL API đúng

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sanPhamList = JsonConvert.DeserializeObject<List<SanPham>>(content); // Chuyển đổi dữ liệu JSON thành đối tượng

                return View(sanPhamList); // Truyền dữ liệu vào view
            }

            return View("Error"); // Nếu không thành công, trả về view lỗi
        }
        public async Task<IActionResult> TreEm()
        {
            // Gọi API để lấy dữ liệu sản phẩm
            var response = await _httpClient.GetAsync("https://localhost:7116/api/SanPham"); // Đảm bảo URL API đúng

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sanPhamList = JsonConvert.DeserializeObject<List<SanPham>>(content); // Chuyển đổi dữ liệu JSON thành đối tượng

                return View(sanPhamList); // Truyền dữ liệu vào view
            }

            return View("Error"); // Nếu không thành công, trả về view lỗi
        }
    }
}
