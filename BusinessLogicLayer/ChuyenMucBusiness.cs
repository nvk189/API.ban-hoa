using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ChuyenMucBusiness:IChuyenMucBusiness
    {
        private IChuyenMucRespository _respository;
        public ChuyenMucBusiness (IChuyenMucRespository respository)
        {
            _respository = respository;
        }

        public bool Create(ChuyenMucModel model)
        {
           return _respository.Create(model);
        }

        public List<ChuyenMucModel> getAll()
        {
            return _respository.getAll();
        }

        public List<ChuyenMucModel> Search(string tenchuyenmuc)
        {
           return _respository.Search(tenchuyenmuc);
        }

        public bool Update(ChuyenMucModel model)
        {
           return _respository.Update(model);
        }
    }
}
