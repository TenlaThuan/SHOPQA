using APIQLQA.Data;
using APIQLQA.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class NguoiDungController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public NguoiDungController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lấy tất cả danh mục
    [HttpGet]
    public async Task<ActionResult<List<NguoiDung>>> GetNguoiDungs()
    {
        return await _context.NguoiDungs.ToListAsync();
    }

    // Lấy danh mục theo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<NguoiDung>> GetNguoiDung(int id)
    {
        var category = await _context.NguoiDungs.FindAsync(id);
        if (category == null) return NotFound();
        return category;
    }

    // Thêm mới danh mục
    [HttpPost]
    public async Task<ActionResult<NguoiDung>> GetNguoiDung(NguoiDung NguoiDung)
    {
        _context.NguoiDungs.Add(NguoiDung);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNguoiDung), new { id = NguoiDung.MaNguoiDung }, NguoiDung);
    }

    // Cập nhật danh mục
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNguoiDung(int id, NguoiDung NguoiDung)
    {
        if (id != NguoiDung.MaNguoiDung) return BadRequest();

        _context.Entry(NguoiDung).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Xóa danh mục
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNguoiDung(int id)
    {
        var NguoiDung = await _context.NguoiDungs.FindAsync(id);
        if (NguoiDung == null) return NotFound();

        _context.NguoiDungs.Remove(NguoiDung);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

