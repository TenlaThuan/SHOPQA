using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace APIQLQA.Model
{
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }

        // Khóa ngoại
        public int MaNguoiDung { get; set; }
        [JsonIgnore] // loại bỏ lặp product ở category
        public virtual NguoiDung? NguoiDung { get; set; }

        public int MaSanPham { get; set; }
        [JsonIgnore] // loại bỏ lặp product ở category
        public virtual SanPham? SanPham { get; set; }

        [Required]
        public int SoLuong { get; set; }

        public DateTime NgayThem { get; set; } = DateTime.Now;
    }
}
