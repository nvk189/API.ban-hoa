using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface IKhachHangRepository
    {
        KhachHangModel GetByID(int id);
        List<KhachHangModel> GetAll();
        bool Create (KhachHangModel model);
        bool Update (KhachHangModel model);
        bool Delete (KhachHangModel model);
        //public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi, string dien_Thoai, bool gioi_Tinh);
        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string ten_khach);

    }
}
