using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoaDonNhapModel
    {
        public int MaHoaDonNhap { get; set; }
        public int MaNhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public int MaTaiKhoan { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_chitiethoadonnhap { get; set; }
    }

    public class ChiTietHoaDonNhapModel
    {
        public int MaChiTietHoaDonNhap { get; set; }
        public int MaHoaDonNhap { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
    }


    public class HoaDonNhapModel1
    {
        public int MaHoaDonNhap { get; set; }
        public int MaNhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public int MaTaiKhoan { get; set; }

    }



}
