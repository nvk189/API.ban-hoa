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

        public HoaDonNhapModel GetDatabyID(int id)
        {
           return _respository.GetDatabyID(id);
        }

        public List<ThongkeModel.HoaDonNhapModel1> thongkeHoaDonnhap(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
           return _respository.thongkeHoaDonnhap( pageIndex, pageSize, out total, fr_NgayTao, to_NgayTao );
        }

        //public List<HoaDonNhapModel1> thongkeHoaDonnhap(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Update(HoaDonNhapModel model)
        {
            return _respository.Update(model);
        }

      
    }
}
