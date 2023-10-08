using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanPhamBusiness;
        public SanPhamController (ISanPhamBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }
        [Route("get-id")]
        [HttpGet]
        public SanPhamModel GetByID(int id)
        {
            return _sanPhamBusiness.GetByID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public List<SanPhamModel1> GetByAll()
        {
            return _sanPhamBusiness.GetAll();
        }

        [Route("create")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            
            _sanPhamBusiness.Create(model);
                return model;
        }

        [Route("update")]
        [HttpPost]
        public SanPhamModel Update([FromBody] SanPhamModel model)
        {

            _sanPhamBusiness.Update(model);
            return model;
        }
        [Route("Delete")]
        [HttpPost]
        public Delete_SanPham Delete([FromBody] Delete_SanPham model)
        {

            _sanPhamBusiness.Delete(model);
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
                string tenSanPham = "";
                if (formData.Keys.Contains("ten_san_pham") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_san_pham"]))) { tenSanPham = Convert.ToString(formData["ten_san_pham"]); }
                string moTa = "";
                if (formData.Keys.Contains("mo_ta") && !string.IsNullOrEmpty(Convert.ToString(formData["mo_ta"]))) { moTa = Convert.ToString(formData["mo_ta"]); }

                long total = 0;
                var data = _sanPhamBusiness.Search(page, pageSize, out total, tenSanPham, moTa);
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
