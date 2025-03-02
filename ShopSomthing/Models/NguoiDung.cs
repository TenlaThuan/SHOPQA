namespace ShopSomthing.Models
{
    public class NguoiDung
    {
        public int MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
        public string VaiTro { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        
    }
}

