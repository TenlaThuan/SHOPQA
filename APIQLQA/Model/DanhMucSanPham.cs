using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace APIQLQA.Model
{
    public class DanhMucSanPham
    {
        [Key]
        public int MaDanhMuc { get; set; }

        [Required, StringLength(100)]
        public string TenDanhMuc { get; set; }

        public string MoTa { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        [JsonIgnore] // loại bỏ lặp product ở category
        // Quan hệ
        public virtual ICollection<SanPham>? SanPhams { get; set; }
    }
}
