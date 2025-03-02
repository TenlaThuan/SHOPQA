using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace APIQLQA.Model
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [Required, StringLength(200)]
        public string TenSanPham { get; set; }

        public string HinhAnh { get; set; }

        [Required, StringLength(50)]
        public string KichThuoc { get; set; }

        public string ThuongHieu { get; set; }

        public string ChatLieu { get; set; }

        public string XuatXu { get; set; }

        [Required]
        public decimal Gia { get; set; }

        public string TrangThai { get; set; } = "Còn hàng";

        // Khóa ngoại
        public int MaDanhMuc { get; set; }

        [JsonIgnore]
        public virtual DanhMucSanPham? DanhMucSanPham { get; set; }
    }
}
