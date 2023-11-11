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
    public class KhachHangBusiness : IKhachHangBusiness
    {
        private IKhachHangRepository _khachHangRepository;
        public KhachHangBusiness (IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        public bool Create(KhachHangModel model)
        {
            return _khachHangRepository.Create(model);
        }

        

        public List<KhachHangModel> GetAll()
        {
            return _khachHangRepository.GetAll();
        }

        public KhachHangModel GetByID(int id)
        {
            return _khachHangRepository.GetByID(id);
        }

        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string ten_khach)
        {
            return _khachHangRepository.Search(pageIndex, pageSize, out total, ten_khach );
        }

        public bool Update(KhachHangModel model)
        {
            return _khachHangRepository.Update(model);
        }
        public bool Delete(KhachHangModel model)
        {
            return _khachHangRepository.Delete(model);
        }
    }
}
