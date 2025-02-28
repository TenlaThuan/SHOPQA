namespace ShopSomthing.Models
{
    public class DonHang
    {
        public int MaGioHang { get; set; }
        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public int MaSanPham { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayThem { get; set; } = DateTime.Now;
    }
}
