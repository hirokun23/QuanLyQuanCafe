using System;

namespace QuanLyQuanCafe.DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string VaiTro { get; set; }
        public decimal Luong { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
}