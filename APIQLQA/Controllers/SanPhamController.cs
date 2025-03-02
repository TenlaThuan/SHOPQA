using APIQLQA.Data;
using APIQLQA.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]

[ApiController]
public class SanPhamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả sản phẩm
        [HttpGet]
        public async Task<ActionResult<List<SanPham>>> GetSanPhams()
        {
            return await _context.SanPhams.Include(p => p.DanhMucSanPham).ToListAsync();
        }

        // Lấy sản phẩm theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetSanPham(int id)
        {
            var sanPham = await _context.SanPhams.Include(p => p.DanhMucSanPham).FirstOrDefaultAsync(p => p.MaSanPham == id);
            if (sanPham == null) return NotFound();
            return sanPham;
        }

    // Thêm sản phẩm
    //[HttpPost]
    //public async Task<ActionResult<Product>> PostProduct([FromForm] Product product, IFormFile image)
    //{
    //    //_context.Products.Add(product);
    //    //await _context.SaveChangesAsync();
    //    //return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

    //    //Tìm Category trước khi lưu để tránh EF tự tạo mới
    //    var category = await _context.Categories.FindAsync(product.CategoryId);
    //    if (category == null)
    //    {
    //        return BadRequest("CategoryId không tồn tại");
    //    }

    //    product.Category = null; // Bỏ object Category để tránh lỗi tự tạo mới
    //    _context.Products.Add(product);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    //}


    //Thay thế hàm trên thành code dưới này nếu Product có hình
    //API chỉ nhập (Id/Name/Price/ CategoryId  và choose file image string ($binary)
    // những trường còn lại bị trùng lặp không cần điền dữ liệu
    /*[HttpPost]
    public async Task<ActionResult<SanPham>> CreateSanPham([FromForm] SanPham sanPham, IFormFile image)
    {
        if (image != null)
        {
            // Tạo thhư mục lưu trữ ảnh
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image");

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Tạo đường dẫn file
            string filePath = Path.Combine(uploadFolder, image.FileName);

            // Lưu file ảnh vào thư mục
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Lưu URL của ảnh vào sản phẩm
            sanPham.HinhAnh = "/image/" + image.FileName;
        }

        _context.SanPhams.Add(sanPham);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSanPham), new { id = sanPham.MaSanPham }, sanPham);
    }*/
    [HttpPost]
    public async Task<IActionResult> CreateSanPham([FromBody] SanPham sanPhamDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var sanPham = new SanPham
        {
            TenSanPham = sanPhamDto.TenSanPham,
            HinhAnh = sanPhamDto.HinhAnh,
            KichThuoc = sanPhamDto.KichThuoc,
            ThuongHieu = sanPhamDto.ThuongHieu,
            ChatLieu = sanPhamDto.ChatLieu,
            XuatXu = sanPhamDto.XuatXu,
            Gia = sanPhamDto.Gia,
            TrangThai = sanPhamDto.TrangThai,
            MaDanhMuc = sanPhamDto.MaDanhMuc // Chỉ lưu ID danh mục
        };

        _context.SanPhams.Add(sanPham);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSanPham), new { id = sanPham.MaSanPham }, sanPham);
    }


    [HttpPost("muti")]
        public async Task<ActionResult> CreateMultipleSanPhams([FromBody] List<SanPham> sanPhams)
        {
            if (sanPhams == null || !sanPhams.Any())
            {
                return BadRequest("Danh sách sản phẩm không được rỗng");
            }

            foreach (var sanPham in sanPhams)
            {
                var danhMuc = await _context.DanhMucSanPhams.FindAsync(sanPham.MaDanhMuc);
                if (danhMuc == null)
                {
                    return BadRequest($"MaDanhMuc {sanPham.MaDanhMuc} không tồn tại");
                }
                sanPham.DanhMucSanPham = null; // Tránh EF Core tạo Category mới
            }

            _context.SanPhams.AddRange(sanPhams);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{sanPhams.Count} sản phẩm đã được thêm thành công!" });
        }


    // Cập nhật sản phẩm
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutProduct(int id, Product product)
    //{
    //    if (id != product.Id) return BadRequest();

    //    _context.Entry(product).State = EntityState.Modified;
    //    await _context.SaveChangesAsync();
    //    return NoContent();
    //}

    //Phần Eidt có cập nhật hình ảnh

    /*[HttpPut("{id}")]
    public async Task<IActionResult> EditSanPham(int id, [FromForm] SanPham sanPham, IFormFile? image)
    {
        var existingProduct = await _context.SanPhams.FindAsync(id);
        if (existingProduct == null)
        {
            return NotFound(new { message = "Sản phẩm không tồn tại" });
        }

        // Cập nhật thông tin sản phẩm
        existingProduct.TenSanPham = sanPham.TenSanPham;
        existingProduct.KichThuoc = sanPham.KichThuoc;
        existingProduct.ThuongHieu = sanPham.ThuongHieu;
        existingProduct.ChatLieu = sanPham.ChatLieu;
        existingProduct.XuatXu = sanPham.XuatXu;
        existingProduct.Gia = sanPham.Gia;
        existingProduct.TrangThai = sanPham.TrangThai;
        // Nếu có upload ảnh mới thì thay thế ảnh cũ
        if (image != null)
        {
            var filePath = Path.Combine("wwwroot/image", image.FileName);

            // Xóa ảnh cũ nếu có
            if (!string.IsNullOrEmpty(existingProduct.HinhAnh))
            {
                var oldImagePath = Path.Combine("wwwroot", existingProduct.HinhAnh.TrimStart('/'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            // Lưu ảnh mới
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            existingProduct.HinhAnh = "/image/" + image.FileName;
        }

        await _context.SaveChangesAsync();
        return Ok(existingProduct);
    }*/
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSanPham(int id, [FromBody] SanPham sanPhamDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var sanPham = await _context.SanPhams.FindAsync(id);
        if (sanPham == null)
        {
            return NotFound(new { message = "Sản phẩm không tồn tại!" });
        }

        // Cập nhật dữ liệu từ DTO vào entity
        sanPham.TenSanPham = sanPhamDto.TenSanPham;
        sanPham.HinhAnh = sanPhamDto.HinhAnh;
        sanPham.KichThuoc = sanPhamDto.KichThuoc;
        sanPham.ThuongHieu = sanPhamDto.ThuongHieu;
        sanPham.ChatLieu = sanPhamDto.ChatLieu;
        sanPham.XuatXu = sanPhamDto.XuatXu;
        sanPham.Gia = sanPhamDto.Gia;
        sanPham.TrangThai = sanPhamDto.TrangThai;
        sanPham.MaDanhMuc = sanPhamDto.MaDanhMuc; // Cập nhật danh mục sản phẩm

        _context.SanPhams.Update(sanPham);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Cập nhật sản phẩm thành công!", sanPham });
    }
    // Xóa sản phẩm
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null) return NotFound();

            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }


