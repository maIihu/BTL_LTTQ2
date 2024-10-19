using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        public string TimNhanVienTheoMa(string maNV)
        {
            string query = "SELECT TenNhanVien FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });

            return result != null ? result.ToString() : null;
        }
        public List<NhanVienDTO> LayDSNhanVien()
        {
            string query = "SELECT * FROM NHANVIEN ";

            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            List<NhanVienDTO> listNhanVien = new List<NhanVienDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                NhanVienDTO nhanVienDTO = new NhanVienDTO
                (
                    row["MaNhanvien"].ToString(),   
                    row["TenNhanVien"].ToString(),
                    DateTime.Parse(row["NgaySinh"].ToString()),
                    row["MaTrinhDo"].ToString(),
                    row["GioiTinh"].ToString(),
                    row["DiaChi"].ToString(),
                    row["SoDienThoai"].ToString(),
                    row["ChucVu"].ToString(),
                    DateTime.Parse(row["NgayBatDau"].ToString())
                );
                listNhanVien.Add(nhanVienDTO);
            }
            return listNhanVien;
        }
        public bool ThemNhanVien (NhanVienDTO nhanVien)
        {
            string query = "INSERT INTO NHANVIEN (MaNhanVien, TenNhanVien, MaTrinhDo, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChucVu, NgayBatDau, LuongCoBan)" +
                " VALUES (@maNhanVien, @tenNhanVien, @maTrinhDo, @ngaySinh, @gioiTinh, @diaChi, @soDienThoai, @chucVu, @ngayBatDau, @luongCoBan)";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { nhanVien.MaNhanVien, nhanVien.TenNhanVien, nhanVien.MaTrinhDo, nhanVien.NgaySinh, nhanVien.GioiTinh,
                    nhanVien.DiaChi, nhanVien.SoDienThoai, nhanVien.ChucVu, nhanVien.NgayBatDau, nhanVien.LuongCoBan });
            return result > 0;
        }

    }
}
