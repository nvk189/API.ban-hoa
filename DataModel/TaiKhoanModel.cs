using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TaiKhoanModel
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int MaLoaiTaiKhoan { get; set; }
        public bool TrangThai { get; set; }
        public List<ChiTietTaiKhoanModel> list_json_chitiettaikhoan { get; set; }
    }

    public class ChiTietTaiKhoanModel
    {
        public int MaChiTietTaiKhoan { get; set; }
        public int MaTaiKhoan { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
    }

    public class TaiKhoanModel1
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int MaLoaiTaiKhoan { get; set; }
        public bool TrangThai { get; set; }
        public string token { get; set; }
        public List<ChiTietTaiKhoanModel> list_json_chitiettaikhoan { get; set; }
    }

}
