using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        IHoaDonNhapBusiness _nhapBusiness;
        public HoaDonNhapController(IHoaDonNhapBusiness nhapBusiness)
        {
            _nhapBusiness = nhapBusiness;
        }

        [Route("get-by-id")]
        [HttpGet]
        public HoaDonNhapModel GetById(int id)
        {
            return _nhapBusiness.GetDatabyID(id);
        }
        [Route("create-hoadon")]
        [HttpPost]
        public HoaDonNhapModel CreateItem([FromBody] HoaDonNhapModel model)
        {
            _nhapBusiness.Create(model);
            return model;
        }
        [Route("update-hoadon")]
        [HttpPost]
        public HoaDonNhapModel Update([FromBody] HoaDonNhapModel model)
        {
            _nhapBusiness.Update(model);
            return model;
        }

        [Route("ThongKeNhap")]
        [HttpPost]
        public IActionResult ThongKeHoaDonNhap([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                DateTime? fr_NgayTao = null;
                if (formData.Keys.Contains("fr_NgayNhap") && formData["fr_NgayNhap"] != null && formData["fr_NgayNhap"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayNhap"].ToString());
                    fr_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayTao = null;
                if (formData.Keys.Contains("to_NgayNhap") && formData["to_NgayNhap"] != null && formData["to_NgayNhap"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayNhap"].ToString());
                    to_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _nhapBusiness.thongkeHoaDonnhap(page, pageSize, out total, fr_NgayTao, to_NgayTao);
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
