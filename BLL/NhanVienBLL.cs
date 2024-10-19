using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL _nhanVienDAL;
        public NhanVienBLL() { 
            _nhanVienDAL = new NhanVienDAL(); 
        }    
        public string TimNhanVienTheoMa(string maNV)
        {
            return _nhanVienDAL.TimTenNhanVienTheoMa(maNV);
        }
        public string TimTrinhDoTheoMa(string maNV)
        {
            return _nhanVienDAL.TimTrinhDoNhanVien(maNV);
        }
        public string TimNgaySinh(string maNV)
        {
            return _nhanVienDAL.TimNgaySinhNhanVien(maNV);
        }
        public string TimGioiTinh(string maNV)
        {
            return _nhanVienDAL.TimGioiTinh(maNV);
        }
        public string TimSoDienThoai(string maNV)
        {
            return _nhanVienDAL.TimSoDienThoai(maNV);
        }
        public string TimNgayBatDau(string maNV)
        {
            return _nhanVienDAL.TimNgayBatDau(maNV);
        }
        public string TimDiaChi(string maNV)
        {
            return _nhanVienDAL.TimDiaChi(maNV);
        }
        public List<NhanVienDTO> LayDSNhanVien()
        {
            return _nhanVienDAL.LayDSNhanVien();    
        }
        public bool ThemNhanVien(NhanVienDTO nhanVienDTO) {
            return _nhanVienDAL.ThemNhanVien(nhanVienDTO);
        }
    }
}
