using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
        public class HoaDonModel
        {
        public int MaDonHang { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public decimal TongTien { get; set; }
        public bool TrangThai { get; set; }
        public List<ChiTietHoaDonModel> list_json_chitiethoadon { get; set; }
        }
        public class ChiTietHoaDonModel
            {
            public int MaChiTietDonHang { get; set; }
            public int MaDonHang { get; set; }
            public int MaSanPham { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
        }
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


}
