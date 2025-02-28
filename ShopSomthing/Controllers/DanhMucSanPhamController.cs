using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ShopSomthing.Models;

public class DanhmucSanPhamController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string apiUrl = "https://localhost:7116/api/DanhmucSanPham";

    public DanhmucSanPhamController()
    {
        _httpClient = new HttpClient();
    }

    // Hiển thị danh sách danh mục sản phẩm
    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetStringAsync(apiUrl);
        var danhMucs = JsonConvert.DeserializeObject<List<DanhMucSanPham>>(response);
        return View(danhMucs);
    }


    // Hiển thị chi tiết danh mục sản phẩm
    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetStringAsync($"{apiUrl}/{id}");
        var danhMuc = JsonConvert.DeserializeObject<DanhMucSanPham>(response);
        if (danhMuc == null) return NotFound();
        return View(danhMuc);
    }

    // Hiển thị form thêm mới danh mục
    public IActionResult Create()
    {
        return View();
    }

    // Xử lý thêm mới danh mục
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DanhMucSanPham danhMucSanPham)
    {
        if (ModelState.IsValid)
        {
            var json = JsonConvert.SerializeObject(danhMucSanPham);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(apiUrl, content);
            return RedirectToAction(nameof(Index));
        }
        return View(danhMucSanPham);
    }

    // Hiển thị form chỉnh sửa danh mục
    public async Task<IActionResult> Edit(int id)
    {
        var response = await _httpClient.GetStringAsync($"{apiUrl}/{id}");
        var danhMuc = JsonConvert.DeserializeObject<DanhMucSanPham>(response);
        if (danhMuc == null) return NotFound();
        return View(danhMuc);
    }

    // Xử lý cập nhật danh mục
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DanhMucSanPham danhMucSanPham)
    {
        if (id != danhMucSanPham.MaDanhMuc) return NotFound();

        if (ModelState.IsValid)
        {
            var json = JsonConvert.SerializeObject(danhMucSanPham);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"{apiUrl}/{id}", content);
            return RedirectToAction(nameof(Index));
        }
        return View(danhMucSanPham);
    }

    // Hiển thị xác nhận xóa
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.GetStringAsync($"{apiUrl}/{id}");
        var danhMuc = JsonConvert.DeserializeObject<DanhMucSanPham>(response);
        if (danhMuc == null) return NotFound();
        return View(danhMuc);
    }

    // Xử lý xóa danh mục
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _httpClient.DeleteAsync($"{apiUrl}/{id}");
        return RedirectToAction(nameof(Index));
    }
}
