using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public  partial interface  IChuyenMucBusiness
    {
        List<ChuyenMucModel> getAll();
        bool Create(ChuyenMucModel model);
        bool Update(ChuyenMucModel model);
        List<ChuyenMucModel> Search(string tenchuyenmuc);
    }
}
