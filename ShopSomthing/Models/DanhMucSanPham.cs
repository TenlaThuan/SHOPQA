namespace ShopSomthing.Models
{
    public class DanhMucSanPham
    {
        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
