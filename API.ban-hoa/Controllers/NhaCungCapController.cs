using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private INhaCungCapBusiness _nhaCungCap;
        public NhaCungCapController (INhaCungCapBusiness nhaCungCap)
        {
            _nhaCungCap = nhaCungCap;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public NhaCungCapModel GetDatabyID(int id)
        {
            return _nhaCungCap.GetByID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public List<NhaCungCapModel> GetAll()
        {
            return _nhaCungCap.GetAll();
        }

        [Route("create")]
        [HttpPost]
        public NhaCungCapModel CreateItem([FromBody] NhaCungCapModel model)
        {
            _nhaCungCap.Create(model);
            return model;
        }

        [Route("update")]
        [HttpPost]
        public NhaCungCapModel UpdateItem([FromBody] NhaCungCapModel model)
        {
            _nhaCungCap.Update(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult SearchNhaCungCap([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenNhaCungCap = "";
                if (formData.Keys.Contains("tenNhaCungCap") && !string.IsNullOrEmpty(Convert.ToString(formData["tenNhaCungCap"]))) { tenNhaCungCap = Convert.ToString(formData["tenNhaCungCap"]); }
                //string diaChi = "";
                //if (formData.Keys.Contains("diaChi") && !string.IsNullOrEmpty(Convert.ToString(formData["diaChi"]))) { diaChi = Convert.ToString(formData["diaChi"]); }
                //string dienThoai = "";
                //if (formData.Keys.Contains("dienThoai") && !string.IsNullOrEmpty(Convert.ToString(formData["dienThoai"]))) { dienThoai = Convert.ToString(formData["dienThoai"]); }
                //string email = "";
                //if (formData.Keys.Contains("email") && !string.IsNullOrEmpty(Convert.ToString(formData["email"]))) { email = Convert.ToString(formData["email"]); }

                long total = 0;
                var data =_nhaCungCap.SearchNhaCungCap(page, pageSize, out total, tenNhaCungCap);
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
