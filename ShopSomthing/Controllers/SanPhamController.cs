using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ShopSomthing.Models;

public class SanPhamController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string apiUrl = "https://localhost:7116/api/SanPham";
    
    public SanPhamController()
    {
        _httpClient = new HttpClient();
    }

    // Hiển thị danh sách danh mục sản phẩm
     public async Task<IActionResult> Index()
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


    // Hiển thị chi tiết danh mục sản phẩm
    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetStringAsync($"{apiUrl}/{id}");
        var sanPham = JsonConvert.DeserializeObject<SanPham>(response);
        if (sanPham == null) return NotFound();
        return View(sanPham);
    }

    // Hiển thị form thêm mới danh mục
    public IActionResult Create()
    {
        return View();
    }

    // Xử lý thêm mới danh mục
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SanPham sanPham)
    {
        if (ModelState.IsValid)
        {
            var json = JsonConvert.SerializeObject(sanPham);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(apiUrl, content);
            return RedirectToAction(nameof(Index));
        }
        return View(sanPham);
    }

    // Hiển thị form chỉnh sửa danh mục
    public async Task<IActionResult> Edit(int id)
    {
        var response = await _httpClient.GetStringAsync($"{apiUrl}/{id}");
        var sanPham = JsonConvert.DeserializeObject<SanPham>(response);
        if (sanPham == null) return NotFound();
        return View(sanPham);
    }

    // Xử lý cập nhật danh mục
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SanPham sanPham)
    {
        if (id != sanPham.MaSanPham) return NotFound();

        if (ModelState.IsValid)
        {
            var json = JsonConvert.SerializeObject(sanPham);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"{apiUrl}/{id}", content);
            return RedirectToAction(nameof(Index));
        }
        return View(sanPham);
    }

    // Hiển thị xác nhận xóa
    public async Task<IActionResult> Delete(int id)
    {
        Console.WriteLine($"📌 Nhận yêu cầu hiển thị trang xóa sản phẩm ID: {id}");

        if (id == 0)
        {
            Console.WriteLine("❌ ID không hợp lệ!");
            return View("Error", new ErrorViewModel { RequestId = "{ id }" });
        }

        var response = await _httpClient.GetAsync($"{apiUrl}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"❌ API trả về lỗi: {response.StatusCode}");
            return View("Error", new ErrorViewModel { RequestId = "Lỗi khi lấy sản phẩm" });
        }

        var content = await response.Content.ReadAsStringAsync();
        var sanPham = JsonConvert.DeserializeObject<SanPham>(content);

        if (sanPham == null)
        {
            Console.WriteLine($"❌ Không tìm thấy sản phẩm ID: {id}");
            return NotFound();
        }

        Console.WriteLine($"✅ Tìm thấy sản phẩm ID: {id}");
        return View(sanPham);
    }
    [HttpPost]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    Console.WriteLine($"📌 Nhận yêu cầu xóa sản phẩm ID: {id}");

    if (id == 0)
    {
        Console.WriteLine("❌ Lỗi: ID sản phẩm không hợp lệ!");
        return View("Error", new ErrorViewModel { RequestId = "{ id }" });
    }

    var response = await _httpClient.DeleteAsync($"{apiUrl}/{id}");

    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"❌ Lỗi API: {response.StatusCode}");
        return View("Error", new ErrorViewModel { RequestId = $"Lỗi: {response.StatusCode}" });
    }

    Console.WriteLine("✅ Xóa thành công sản phẩm!");
    return RedirectToAction("Index");
}


}
