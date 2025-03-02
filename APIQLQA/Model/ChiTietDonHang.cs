using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace APIQLQA.Model
{
    public class ChiTietDonHang
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int MaDonHang { get; set; }
        [JsonIgnore] // loại bỏ lặp product ở category
        public virtual DonHang? DonHang { get; set; }

        public int MaSanPham { get; set; }
        [JsonIgnore] // loại bỏ lặp product ở category
        public virtual SanPham? SanPham { get; set; }

        [Required]
        public int SoLuong { get; set; }

        [Required]
        public decimal GiaBan { get; set; }
    }

}
