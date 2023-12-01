using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static DataModel.ThongkeModel;

namespace BusinessLogicLayer
{
    public class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonReponsitory _hoaDon;
        public HoaDonBusiness(IHoaDonReponsitory hoaDon)
        {
            _hoaDon = hoaDon;
        }

        public bool Create(HoaDonModel model)
        {
            return _hoaDon.Create(model);
        }

        public HoaDonModel GetDatabyID(int id)
        {
            return _hoaDon.GetDatabyID(id);
        }

        public bool Update(HoaDonModel model)
        {
            return _hoaDon.Update(model);
        }

        public List<HoaDonModel> GetAll()
        {
            return _hoaDon.GetAll();
        }



        //public List<HoaDonModel1> SearchHoaDon1(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        //{
        //    return _hoaDon.SearchHoaDon1(pageIndex, pageSize, out total, fr_NgayTao, to_NgayTao);
        //}

        public List<HoaDonModel> SearchHoaDon(int pageIndex, int pageSize, out long total, int? maDonHang, string dienThoai, bool trangThai, DateTime? ngayDatHangStart, DateTime? ngayDatHangEnd)
        {
            return _hoaDon.SearchHoaDon(pageIndex, pageSize, out total, maDonHang, dienThoai, trangThai, ngayDatHangStart, ngayDatHangEnd);
        }

        public HoaDonModel Delete(int id)
        {
            return _hoaDon.Delete(id);
        }

        public List<HoaDonModel> SearchHoaDon1(DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
           return _hoaDon.SearchHoaDon1(fr_NgayTao, to_NgayTao);
        }
    }
}
