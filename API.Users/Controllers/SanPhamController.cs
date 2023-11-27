using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _business;
        public SanPhamController (ISanPhamBusiness business)
        {
            _business = business;
        }
        [Route("get-id/{id}")]
        [HttpGet]
        public SanPhamModel GetByID(int id)
        {
            return _business.GetByID(id);
        }
        [Route("get-chuyenmuc")]
        [HttpGet]
        public List<SanPhamModel1> chuyenmuc_sp(int chuyenmuc)
        {
            return _business.chuyenmuc_sp(chuyenmuc);
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
                if (formData.Keys.Contains("tenSanPham") && !string.IsNullOrEmpty(Convert.ToString(formData["tenSanPham"])))
                {
                    tenSanPham = Convert.ToString(formData["tenSanPham"]);
                }
                int maSanPham = 0;
                if (formData.Keys.Contains("maSanPham") && !string.IsNullOrEmpty(formData["maSanPham"].ToString()))
                {
                    if (int.TryParse(formData["maSanPham"].ToString(), out int maSanPhamValue))
                    {
                        maSanPham = maSanPhamValue;
                    }
                }

                int maChuyenMuc = 0;
                if (formData.Keys.Contains("maChuyenMuc") && !string.IsNullOrEmpty(formData["maChuyenMuc"].ToString()))
                {
                    if (int.TryParse(formData["maChuyenMuc"].ToString(), out int maChuyenMucValue))
                    {
                        maChuyenMuc = maChuyenMucValue;
                    }
                }

                bool trangThai = true;
                if (formData.Keys.Contains("trangThai"))
                {
                    if (bool.TryParse(formData["trangThai"].ToString(), out bool trangThaiValue))
                    {
                        trangThai = trangThaiValue;
                    }
                }

                long total = 0;
                var data = _business.Search(page, pageSize, out total, maSanPham, tenSanPham, maChuyenMuc, trangThai);
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
                return BadRequest(ex.Message);
            }
        }

    }
}
