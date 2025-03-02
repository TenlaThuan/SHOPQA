using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace APIQLQA.Model
{
    public class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }

        public int MaNguoiDung { get; set; }
        [JsonIgnore] // loại bỏ lặp product ở category
        public virtual NguoiDung? NguoiDung { get; set; }

        [Required]
        public decimal TongTien { get; set; }

        public string TrangThai { get; set; } = "ChoXacNhan"; // ChoXacNhan, DangXuLy, DaGiao, HoanThanh, Huy

        public DateTime NgayDat { get; set; } = DateTime.Now;

        [JsonIgnore] // loại bỏ lặp product ở category
        // Quan hệ
        public virtual ICollection<ChiTietDonHang>? ChiTietDonHangs { get; set; }
    }
}
