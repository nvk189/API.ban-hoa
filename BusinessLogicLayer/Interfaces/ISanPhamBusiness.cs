using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public  partial interface ISanPhamBusiness
    {
        SanPhamModel GetByID(int id);
        List<SanPhamModel> GetAll();
        bool Create (SanPhamModel model);
        bool Update (SanPhamModel model);
        SanPhamModel Delete(int id);
        List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, int maSanPham, string tenSanPham, int maChuyenMuc, bool trangThai);
        //List<SanPhamModel1> ThongKeSanPham(int id);
        List<SanPhamModel1> chuyenmuc_sp(int chuyenMuc);
    }
}
