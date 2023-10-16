using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataModel.ThongkeModel;

namespace DataAccessLayer.Interfaces
{
    public partial interface IHoaDonNhapRespository
    {

        HoaDonNhapModel GetDatabyID(int id);
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        List<ThongkeModel.HoaDonNhapModel1> thongkeHoaDonnhap(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
