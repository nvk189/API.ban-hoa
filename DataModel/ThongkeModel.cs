using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public  class ThongkeModel
    {

        /////// thống kê hóa đơn theo ngày
        public class HoaDonModel1
        {
            public int MaDonHang { get; set; }
            public string HoTen { get; set; }
            public string DienThoai { get; set; }
            public string DiaChi { get; set; }
            public DateTime NgayDatHang { get; set; }
            public DateTime NgayGiaoHang { get; set; }
            public decimal TongTien { get; set; }
            public string TrangThai { get; set; }
        }

        ////// thống kê hóa đơn nhập
        
    }
}
