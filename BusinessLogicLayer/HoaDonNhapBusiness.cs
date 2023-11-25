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
    public  class HoaDonNhapBusiness:IHoaDonNhapBusiness
    {
        private IHoaDonNhapRespository _respository;
        public HoaDonNhapBusiness (IHoaDonNhapRespository respository)
        {
            _respository = respository;
        }

        public bool Create(HoaDonNhapModel model)
        {
            return _respository.Create(model);
        }

        public List<HoaDonNhapModel> GetAll()
        {
            return _respository.GetAll();
        }

        public HoaDonNhapModel GetDatabyID(int id)
        {
           return _respository.GetDatabyID(id);
        }

        public List<HoaDonNhapModel> SearchHoaDonNhap(int pageIndex, int pageSize, out long total, int? maHoaDonNhap, int? maNhaCungCap, DateTime? ngayNhapStart, DateTime? ngayNhapEnd, int? maTaiKhoan)
        {
            return _respository.SearchHoaDonNhap(pageIndex, pageSize, out total, maHoaDonNhap, maNhaCungCap, ngayNhapStart, ngayNhapEnd, maTaiKhoan);
        }

        public bool Update(HoaDonNhapModel model)
        {
            return _respository.Update(model);
        }

      
    }
}
