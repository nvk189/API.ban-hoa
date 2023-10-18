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
        List<SanPhamModel1> GetAll();
        bool Create (SanPhamModel model);
        bool Update (SanPhamModel model);
        bool Delete(Delete_SanPham model);
        List<SanPhamModel1> Search(int pageIndex, int pageSize, out long total, int maSanPham, string tenSanPham, int maChuyenMuc, bool trangThai);
    }
}
