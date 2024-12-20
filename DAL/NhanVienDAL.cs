﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienDAL
    {
        public string TimTenNhanVienTheoMa(string maNV)
        {
            string query = "SELECT TenNhanVien FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });

            return result != null ? result.ToString() : null;
        }
        public string TimTrinhDoNhanVien(string maNV) {
            string query = "SELECT MaTrinhDo FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });

            return result != null ? result.ToString() : null;
        }
        public string TimNgaySinhNhanVien(string maNV)
        {
            string query = "SELECT NgaySinh FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });


            if (result != null && result is DateTime)
            {
                return ((DateTime)result).ToString("dd/MM/yyyy");
            }

            return null;
        }
        public string TimGioiTinh(string maNV)
        {
            string query = "SELECT GioiTinh FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });

            return result != null ? result.ToString() : null;
        }
        public string TimSoDienThoai(string maNV)
        {
            string query = "SELECT SoDienThoai FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });

            return result != null ? result.ToString() : null;
        }
        public string TimNgayBatDau(string maNV)
        {
            string query = "SELECT NgayBatDau FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });

            if (result != null && result is DateTime)
            {
                return ((DateTime)result).ToString("dd/MM/yyyy");
            }

            return null;
        }

        public string TimDiaChi(string maNV)
        {
            string query = "SELECT DiaChi FROM NHANVIEN WHERE MaNhanVien = @maNV";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maNV });

            return result != null ? result.ToString() : null;
        }

		public bool CapNhatThongTinDayDu(string maNV, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string mtd, DateTime ngaybd)
		{
			string query = "UPDATE NHANVIEN SET TenNhanVien = @hoten , MaTrinhDo = @mtd , NgaySinh = @ngaysinh , " +
				"GioiTinh = @gioitinh , DiaChi = @diachi , SoDienThoai = @sdt , NgayBatDau = @nbd WHERE MaNhanVien = @manv";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoTen, mtd, ngaySinh, gioiTinh, diaChi, sdt, ngaybd, maNV });
			return result > 0;
		}

		public bool CapNhatThongTin(string maNV, string hoTen, string ngaySinh, string gioiTinh, string diaChi, string sdt)
        {
            string query = "UPDATE NHANVIEN SET TenNhanVien = @hoten , NgaySinh = @ngaysinh , " +
                "GioiTinh = @gioitinh , DiaChi = @diachi , SoDienThoai = @sdt WHERE MaNhanVien = @manv";
            DateTime ngaySinhDate;
            if (!DateTime.TryParse(ngaySinh, out ngaySinhDate))
            {
                return false;
            }
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoTen, ngaySinhDate, gioiTinh, diaChi, sdt, maNV });
            return result > 0;
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
                    DateTime.Parse(row["NgayBatDau"].ToString())
                );
                listNhanVien.Add(nhanVienDTO);
            }
            return listNhanVien;
        }

        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            string query = "INSERT INTO NHANVIEN (MaNhanVien, TenNhanVien, " +
                "MaTrinhDo, NgaySinh, GioiTinh,  SoDienThoai,  NgayBatDau, DiaChi)" +
                " VALUES ( @maNhanVien , @tenNhanVien , @maTrinhDo , @ngaySinh , " +
                "@gioiTinh , @soDienThoai , @ngayBatDau , @diaChi )";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { nhanVien.MaNhanVien, nhanVien.TenNhanVien, nhanVien.MaTrinhDo, nhanVien.NgaySinh, nhanVien.GioiTinh,
                    nhanVien.SoDienThoai, nhanVien.NgayBatDau, nhanVien.DiaChi, });
            return result > 0;
        }

    }
}
