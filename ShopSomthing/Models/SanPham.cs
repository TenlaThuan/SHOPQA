namespace ShopSomthing.Models
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string KichThuoc { get; set; }
        public string ThuongHieu { get; set; }
        public string ChatLieu { get; set; }
        public string XuatXu { get; set; }
        public decimal Gia { get; set; }
        public string TrangThai { get; set; } = "Còn hàng";
        public int MaDanhMuc { get; set; }
        public virtual DanhMucSanPham? DanhMucSanPham { get; set; }
    }
}
