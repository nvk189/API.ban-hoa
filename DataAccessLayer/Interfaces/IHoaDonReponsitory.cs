﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static DataModel.ThongkeModel;

namespace DataAccessLayer.Interfaces
{
    public partial interface IHoaDonReponsitory
    {
        HoaDonModel GetDatabyID(int id);
        bool Create(HoaDonModel model);
        bool Update(HoaDonModel model);
        HoaDonModel Delete(int id);
        List<HoaDonModel1> GetAll();
        List<HoaDonModel1> SearchHoaDon(int pageIndex, int pageSize, out long total, int? maDonHang, string dienThoai, bool trangThai, DateTime? ngayDatHangStart, DateTime? ngayDatHangEnd);
        //List<HoaDonModel1> SearchHoaDon1(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
