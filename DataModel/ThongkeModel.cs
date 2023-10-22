using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public  class ThongKeModel
    {
        /// thống kê hóa đơn nhập, hóa đơn bán.
       
            public int MaDonHang { get; set; }
            public string HoTen { get; set; }
            public string DienThoai { get; set; }
            public string DiaChi { get; set; }
            public DateTime NgayDatHang { get; set; }
            public DateTime NgayGiaoHang { get; set; }
            public decimal TongTien { get; set; }
            public int MaHoaDonNhap { get; set; }
            public int MaNhaCungCap { get; set; }
            public DateTime NgayNhap { get; set; }
        


    }
}
