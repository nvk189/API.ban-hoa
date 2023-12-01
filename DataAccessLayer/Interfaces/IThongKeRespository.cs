using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
     public  partial interface IThongKeRespository
    {
        List<ThongKeModel> ThongKeHoaDon(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao, int LoaiThongKe);
        List<SanPhamModel1> ThongkeSanPham(int id);
        List<SanPhamModel1> Thongkedoanhthu( DateTime @fr_NgayTao ,DateTime @to_NgayTao);
        List<HoaDonModel> ThongkeHoaDonBan(DateTime @fr_NgayTao, DateTime @to_NgayTao);
        List<HoaDonNhapModel> ThongkeHoaDonNhap(DateTime @fr_NgayTao, DateTime @to_NgayTao);
    }
}
