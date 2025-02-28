using APIQLQA.Data;
using APIQLQA.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class DanhmucSanPhamController : ControllerBase
    {
    private readonly ApplicationDbContext _context;

    public DanhmucSanPhamController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lấy tất cả danh mục
    [HttpGet]
    public async Task<ActionResult<List<DanhMucSanPham>>> GetDanhMucSanPhams()
    {
        return await _context.DanhMucSanPhams.ToListAsync();
    }

    // Lấy danh mục theo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<DanhMucSanPham>> GetDanhMucSanPham(int id)
    {
        var category = await _context.DanhMucSanPhams.FindAsync(id);
        if (category == null) return NotFound();
        return category;
    }

    // Thêm mới danh mục
    [HttpPost]
    public async Task<ActionResult<DanhMucSanPham>> GetDanhMucSanPham(DanhMucSanPham danhMucSanPham)
    {
        _context.DanhMucSanPhams.Add(danhMucSanPham);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDanhMucSanPham), new { id = danhMucSanPham.MaDanhMuc }, danhMucSanPham);
    }

    // Cập nhật danh mục
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDanhMucSanPham(int id, DanhMucSanPham danhMucSanPham)
    {
        if (id != danhMucSanPham.MaDanhMuc) return BadRequest();

        _context.Entry(danhMucSanPham).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Xóa danh mục
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDanhMucSanPham(int id)
    {
        var danhMucSanPham = await _context.DanhMucSanPhams.FindAsync(id);
        if (danhMucSanPham == null) return NotFound();

        _context.DanhMucSanPhams.Remove(danhMucSanPham);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

