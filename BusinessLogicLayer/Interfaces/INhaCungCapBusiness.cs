using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface INhaCungCapBusiness
    {
        NhaCungCapModel GetByID(int id);
        List<NhaCungCapModel> GetAll();
        bool Create(NhaCungCapModel model);
        bool Update(NhaCungCapModel model);
        //List<NhaCungCapModel> SearchNhaCungCap(int pageIndex, int pageSize, out long total, string tenNhaCungCap, string diaChi, string dienThoai, string email);
        List<NhaCungCapModel> SearchNhaCungCap(int pageIndex, int pageSize, out long total, string tenNhaCungCap);
    }
}
