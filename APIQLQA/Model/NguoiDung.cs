using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace APIQLQA.Model
{
    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }

        [Required, StringLength(100)]
        public string HoTen { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MatKhau { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Required]
        public string VaiTro { get; set; } // "QuanTri" hoặc "KhachHang"

        public DateTime NgayTao { get; set; } = DateTime.Now;

        [JsonIgnore] // loại bỏ lặp product ở category
        // Quan hệ
        public virtual ICollection<DonHang>? DonHangs { get; set; }
    }
}
