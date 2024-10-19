using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public NhanVienDTO(string tenNhanVien, DateTime ngaySinh, string diaChi, string soDienThoai,
            string chucVu, DateTime ngayBatDau)
        {
            this.TenNhanVien = tenNhanVien;
            this.NgaySinh = ngaySinh;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
            this.NgayBatDau = ngayBatDau;
        }

        public NhanVienDTO(string maNhanVien, string tenNhanVien, DateTime ngaySinh, string maTrinhDo,
            string gioiTinh, string diaChi, string soDienThoai, DateTime ngayBatDau)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            NgaySinh = ngaySinh;
            MaTrinhDo = maTrinhDo;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            NgayBatDau = ngayBatDau;
        }

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MaTrinhDo { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayBatDau { get; set; }
    }
}