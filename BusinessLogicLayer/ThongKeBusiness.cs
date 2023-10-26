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
        public List<ThongKeModel> ThongKeHoaDon(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao, int LoaiThongKe)
        {
          return _thongKeRespository.ThongKeHoaDon(pageIndex, pageSize, out total ,fr_NgayTao ,to_NgayTao, LoaiThongKe);
        }
        public List<SanPhamModel1> ThongKeSanPham(int id)
        {
            return _thongKeRespository.ThongkeSanPham(id);
        }

    }
}
