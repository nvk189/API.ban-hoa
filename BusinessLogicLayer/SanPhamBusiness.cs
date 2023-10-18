using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
     public  class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness (ISanPhamRepository res)
        {
            _res = res; 
        }

        public bool Create(SanPhamModel model)
        {
           return _res.Create(model);
        }

        public bool Delete(Delete_SanPham model)
        {
            return _res.Delete(model);
        }

        public List<SanPhamModel1> GetAll()
        {
            return _res.GetAll();   
        }

        public SanPhamModel GetByID(int id)
        {
            return _res.GetByID(id);
        }

        public List<SanPhamModel1> Search(int pageIndex, int pageSize, out long total, int maSanPham, string tenSanPham, int maChuyenMuc, bool trangThai)
        {
            return _res.Search(pageIndex, pageSize, out total,  maSanPham, tenSanPham , maChuyenMuc ,trangThai);
        }

        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
    }
}
