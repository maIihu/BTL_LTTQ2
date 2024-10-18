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
            return _nhanVienDAL.TimNhanVienTheoMa(maNV);
        }
        public List<NhanVienDTO> LayDSNhanVien()
        {
            return _nhanVienDAL.LayDSNhanVien();
        }
        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            return _nhanVienDAL.ThemNhanVien(nhanVien);
        }
    }
}
