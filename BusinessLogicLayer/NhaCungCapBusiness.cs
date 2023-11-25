using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NhaCungCapBusiness:INhaCungCapBusiness
    {
        private INhaCungCapRespository _respository;
        public NhaCungCapBusiness (INhaCungCapRespository respository)
        {
            _respository = respository;
        }

        public bool Create(NhaCungCapModel model)
        {
            return _respository.Create(model);
        }

        public List<NhaCungCapModel> GetAll()
        {
            return _respository.GetAll();
        }

        public NhaCungCapModel GetByID(int id)
        {
            return _respository.GetByID(id);
        }

        public List<NhaCungCapModel> SearchNhaCungCap(int pageIndex, int pageSize, out long total, string tenNhaCungCap)
        {
            return _respository.SearchNhaCungCap(pageIndex ,pageSize ,out total ,tenNhaCungCap );
        }

        public bool Update(NhaCungCapModel model)
        {
            return _respository.Update(model);
        }
    }
}
