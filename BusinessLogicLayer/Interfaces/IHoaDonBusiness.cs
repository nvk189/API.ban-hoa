﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataModel.ThongkeModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial  interface IHoaDonBusiness
    {
        HoaDonModel GetDatabyID(int id);
        bool Create(HoaDonModel model);
        bool Update(HoaDonModel model);
        List<HoaDonModel1> GetAll();
        List<HoaDonModel> SearchHoaDon(int pageIndex, int pageSize, out long total, int maDonHang, string hoTen, string dienThoai, string trangThai, DateTime? ngayDatHang);
        List<HoaDonModel1> SearchHoaDon1(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
