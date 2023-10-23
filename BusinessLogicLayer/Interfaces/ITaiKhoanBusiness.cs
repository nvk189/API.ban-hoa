﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public  partial interface ITaiKhoanBusiness
    {
        TaiKhoanModel1 Login(string taikhoan, string matkhau);
        bool Create(TaiKhoanModel model);
        bool Update(TaiKhoanModel model);
        TaiKhoanModel1 Delete(int id);
        TaiKhoanModel1 GetId(int id);
        List<TaiKhoanModel1> GetLoaiTaiKhoan(int loaiTaiKhoan);
    }
}
