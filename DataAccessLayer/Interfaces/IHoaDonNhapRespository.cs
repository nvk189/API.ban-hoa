﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Interfaces
{
    public partial interface IHoaDonNhapRespository
    {

        HoaDonNhapModel GetDatabyID(int id);
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        List<HoaDonNhapModel> SearchHoaDonNhap(int pageIndex, int pageSize, out long total, int? maHoaDonNhap, int? maNhaCungCap, DateTime? ngayNhapStart, DateTime? ngayNhapEnd, int? maTaiKhoan);
    }
}
