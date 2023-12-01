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
    public class ThongKeBusiness : IThongKeBusinesscs
    {
        private IThongKeRespository _thongKeRespository;
        public ThongKeBusiness (IThongKeRespository thongKeRespository)
        {
            _thongKeRespository = thongKeRespository;
        }

        public List<SanPhamModel1> Thongkedoanhthu(DateTime fr_NgayTao, DateTime to_NgayTao)
        {
            return _thongKeRespository.Thongkedoanhthu (fr_NgayTao, to_NgayTao);
        }

        public List<ThongKeModel> ThongKeHoaDon(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao, int LoaiThongKe)
        {
          return _thongKeRespository.ThongKeHoaDon(pageIndex, pageSize, out total ,fr_NgayTao ,to_NgayTao, LoaiThongKe);
        }

        public List<HoaDonModel> ThongkeHoaDonBan(DateTime fr_NgayTao, DateTime to_NgayTao)
        {
            return _thongKeRespository.ThongkeHoaDonBan(fr_NgayTao, to_NgayTao);
        }
        public List<HoaDonNhapModel> ThongkeHoaDonNhap(DateTime fr_NgayTao, DateTime to_NgayTao)
        {
            return _thongKeRespository.ThongkeHoaDonNhap(fr_NgayTao, to_NgayTao);
        }

        public List<SanPhamModel1> ThongKeSanPham(int id)
        {
            return _thongKeRespository.ThongkeSanPham(id);
        }

    }
}
