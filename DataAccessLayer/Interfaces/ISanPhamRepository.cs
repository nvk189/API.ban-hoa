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
        List<SanPhamModel1> GetAll();
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(Delete_SanPham model);

        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total,int ma_sanpham, string ten_sanpham, int ma_chuyen_muc, bool trang_thai);
    }
}
