using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ISanPhamRepository
    {
        SanPhamModel GetByID(int id);
        List<SanPhamModel> GetAll();
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        SanPhamModel Delete(int id);
        List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, int maSanPham, string tenSanPham, int maChuyenMuc,  bool trangThai);
        //List<SanPhamModel1> ThongkeSanPham(int id);
        List<SanPhamModel1>chuyenmuc_sp(int chuyenMuc);
    }
}
