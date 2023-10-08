using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _HoaDonBusiness;
        public HoaDonController (IHoaDonBusiness hoaDonBusiness)
        {
            _HoaDonBusiness = hoaDonBusiness;
        }

        [Route("get-by-id")]
        [HttpGet]
        public HoaDonModel GetById (int id)
        {
            return _HoaDonBusiness.GetDatabyID(id);
        }
        [Route("create-hoadon")]
        [HttpPost]
        public HoaDonModel CreateItem([FromBody] HoaDonModel model)
        {
            _HoaDonBusiness.Create(model);
            return model;
        }
        [Route("update-hoadon")]
        [HttpPost]
        public HoaDonModel Update([FromBody] HoaDonModel model)
        {
            _HoaDonBusiness.Update(model);
            return model;
        }

    }
}
