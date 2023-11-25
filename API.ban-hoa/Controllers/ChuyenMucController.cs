using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenMucController : ControllerBase
    {
        private IChuyenMucBusiness _chuyenMucBusiness;
        public ChuyenMucController (IChuyenMucBusiness chuyenMucBusiness)
        {
            _chuyenMucBusiness = chuyenMucBusiness;
        }
        [Route("get-all")]
        [HttpGet]
        public List<ChuyenMucModel> GetAll()
        {
            return _chuyenMucBusiness.getAll();
        }
        [Route("create")]
        [HttpPost]
        public ChuyenMucModel CreateItem([FromBody] ChuyenMucModel model)
        {
            _chuyenMucBusiness.Create(model);
            return model;
        }

        [Route("update")]
        [HttpPost]
        public ChuyenMucModel UpdateItem([FromBody] ChuyenMucModel model)
        {
            _chuyenMucBusiness.Update(model);
            return model;
        }
        [Route("search/{tenchuyenmuc}")]
        [HttpGet]
        public List<ChuyenMucModel> Search(string tenchuyenmuc)
        {
            return _chuyenMucBusiness.Search(tenchuyenmuc);
        }

    }
}
