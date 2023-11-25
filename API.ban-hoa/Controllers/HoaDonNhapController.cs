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

        [Route("get-all")]
        [HttpGet]
        public List<HoaDonNhapModel> GetByAll()
        {
            return _nhapBusiness.GetAll();
        }
        [Route("get-by-id/{id}")]
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

        [Route("SearchHoaDonNhap")]
        [HttpPost]
        public IActionResult SearchHoaDonNhap([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int maHoaDonNhap = 0;
                if (formData.Keys.Contains("maHoaDonNhap") && !string.IsNullOrEmpty(formData["maHoaDonNhap"].ToString()))
                {
                    if (int.TryParse(formData["maHoaDonNhap"].ToString(), out int maHoaDonNhapValue))
                    {
                        maHoaDonNhap = maHoaDonNhapValue;
                    }
                }
                int maNhaCungCap = 0;
                if (formData.Keys.Contains("maNhaCungCap") && !string.IsNullOrEmpty(formData["maNhaCungCap"].ToString()))
                {
                    if (int.TryParse(formData["maNhaCungCap"].ToString(), out int maNhaCungCapValue))
                    {
                        maNhaCungCap = maNhaCungCapValue;
                    }
                }
                DateTime? ngayNhapStart = null;
                if (formData.Keys.Contains("ngayNhapStart") && formData["ngayNhapStart"] != null && formData["ngayNhapStart"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["ngayNhapStart"].ToString());
                    ngayNhapStart = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? ngayNhapEnd = null;
                if (formData.Keys.Contains("ngayNhapEnd") && formData["ngayNhapEnd"] != null && formData["ngayNhapEnd"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["ngayNhapEnd"].ToString());
                    ngayNhapEnd = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                int maTaiKhoan = 0;
                if (formData.Keys.Contains("maTaiKhoan") && !string.IsNullOrEmpty(formData["maTaiKhoan"].ToString()))
                {
                    if (int.TryParse(formData["maTaiKhoan"].ToString(), out int maTaiKhoanValue))
                    {
                        maTaiKhoan = maTaiKhoanValue;
                    }
                }
                long total = 0;
                var data = _nhapBusiness.SearchHoaDonNhap(page, pageSize, out total, maHoaDonNhap, maNhaCungCap, ngayNhapStart, ngayNhapEnd, maTaiKhoan);
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
