﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PhuTungBLL
    {
        private PhuTungDAL _phuTungDAL;
        public PhuTungBLL()
        {
            _phuTungDAL = new PhuTungDAL();
        }
        public PhuTungDTO LayPhuTung(string maPt)
        {
            var result = _phuTungDAL.LayPhuTung(maPt);
            if (result != null)
            {
                return new PhuTungDTO
                {
                    TenPhuTung = result[0].ToString(),
                    SoLuong = int.Parse(result[1].ToString()),
                    DonGiaNhap = decimal.Parse(result[2].ToString()),
                    DonGiaBan = decimal.Parse(result[3].ToString())
                };
            }
            return null; // Trả về null nếu không tìm thấy bản ghi
        }
        public string LayMaHoaDonLonNhat()
        {
            return _phuTungDAL.LayMaHoaDonLonNhat();    
        }
        public bool TimPhuTung(string ma)
        {
            return _phuTungDAL.KiemTraPhuTung(ma);
        }
        public bool XoaPhuTung(string maPt)
        {
            return _phuTungDAL.XoaPhuTung(maPt);
        }

		public bool SuaSLPhuTung(string ma, int sl)
        {
            return _phuTungDAL.SuaSLPhuTung(ma, sl);
        }
		public bool SuaPhuTung(string ma, string ten, int sl, decimal dgn, decimal dgb)
		{
			return _phuTungDAL.SuaPhuTung(ma, ten, sl, dgn, dgb);
		}
		public bool ThemPhuTung(PhuTungDTO phuTung)
        {
            return _phuTungDAL.ThemPhuTung(phuTung);
        }
        public List<PhuTungDTO> TimDsTheoTen(string ma)
        {
            return _phuTungDAL.TimDsTheoTen(ma);
        }
        public List<PhuTungDTO> LayDSPhuTung()
        {
            return _phuTungDAL.LayDSKhoPhuTung();
        }

    }
}
