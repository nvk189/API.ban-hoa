using DataModel;
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
    }
}
