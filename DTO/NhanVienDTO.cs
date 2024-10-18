using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public NhanVienDTO(string tenNhanVien, DateTime ngaySinh, string diaChi, string soDienThoai, string chucVu, DateTime ngayBatDau, decimal luongCoBan) {
            this.TenNhanVien = tenNhanVien;
            
            this.NgaySinh = ngaySinh;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
            this.ChucVu = chucVu;
            this.NgayBatDau = ngayBatDau;
            this.LuongCoBan = luongCoBan;
        }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MaTrinhDo { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayBatDau { get; set; }
        public decimal LuongCoBan { get; set; }
    }
}
