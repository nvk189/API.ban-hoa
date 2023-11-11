using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBusiness _res;
        public KhachHangController(IKhachHangBusiness res)
        {
            _res = res;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhachHangModel GetDatabyID(int id)
        {
            return _res.GetByID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public List<KhachHangModel> GetAll()
        {
            return _res.GetAll();
        }

        [Route("create-khach")]
        [HttpPost]
        public KhachHangModel CreateItem([FromBody] KhachHangModel model)
        {
            _res.Create(model);
            return model;
        }

        [Route("update-khach")]
        [HttpPost]
        public KhachHangModel UpdateItem([FromBody] KhachHangModel model)
        {
            _res.Update(model);
            return model;
        }
        [Route("delete-khach")]
        [HttpPost]
        public KhachHangModel DeleteItem([FromBody] KhachHangModel model)
        {
            _res.Delete(model);
            return model;
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_khach = "";
                if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
                //string dia_chi = "";
                //if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
                //string dien_Thoai = "";
                //if (formData.Keys.Contains("dien_Thoai") && !string.IsNullOrEmpty(Convert.ToString(formData["dien_Thoai"]))) { dia_chi = Convert.ToString(formData["dien_Thoai"]); }
                //bool gioi_Tinh = true;
                //if (formData.Keys.Contains("gioi_Tinh") && !string.IsNullOrEmpty(Convert.ToString(formData["gioi_Tinh"]))) { dia_chi = Convert.ToString(formData["gioi_Tinh"]); }
                
                long total = 0;
                var data = _res.Search(page, pageSize, out total, ten_khach);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                    throw new Exception(ex.Message);
            }

        }
        
    }
}
