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
        List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string tenSanPham, string moTa);
    }
}
