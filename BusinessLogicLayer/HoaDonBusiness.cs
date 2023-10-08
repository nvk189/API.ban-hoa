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
    public class HoaDonBusiness:IHoaDonBusiness
    {
        private IHoaDonReponsitory _hoaDon;
        public HoaDonBusiness (IHoaDonReponsitory hoaDon)
        {
            _hoaDon = hoaDon;
        }

        public bool Create(HoaDonModel model)
        {
            return _hoaDon.Create(model);
        }

        public HoaDonModel GetDatabyID(int id)
        {
            return _hoaDon.GetDatabyID(id);
        }

        public bool Update(HoaDonModel model)
        {
            return _hoaDon.Update(model);
        }

        public List<HoaDonModel1> GetAll()
        {
            return _hoaDon.GetAll();
        }
    }
}
