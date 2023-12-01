using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public  partial interface ITaiKhoanRepository
    {
        TaiKhoanModel1 Login(string taikhoan, string matkhau);
        bool Create(TaiKhoanModel model);
        bool Update_admin(TaiKhoanModel model);
        TaiKhoanModel1 Delete(int id);
        TaiKhoanModel GetId (int id);
        List<TaiKhoanModel> GetLoaiTaiKhoan(int loaiTaiKhoan);
        List<TaiKhoanModel> GetAll();
        bool Update_tk_user(TaiKhoanModel model);
        bool Update_pass_user(ChiTietTaiKhoanModel model);

    }
}
