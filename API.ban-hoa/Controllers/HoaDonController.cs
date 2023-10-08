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
        [Route("get-all")]
        [HttpGet]
        public List<HoaDonModel1> GetAll()
        {
            return _HoaDonBusiness.GetAll();
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
        [Route("search-hoadon")]
        [HttpPost]
        public IActionResult SearchHoaDon([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var pageIndex = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int maDonHang = 0;
                if (formData.Keys.Contains("maDonHang") && !string.IsNullOrEmpty(Convert.ToString(formData["maDonHang"]))) { maDonHang = int.Parse(Convert.ToString(formData["maDonHang"])); }
                string hoTen = "";
                if (formData.Keys.Contains("hoTen") && !string.IsNullOrEmpty(Convert.ToString(formData["hoTen"]))) { hoTen = Convert.ToString(formData["hoTen"]); }
                string dienThoai = "";
                if (formData.Keys.Contains("dienThoai") && !string.IsNullOrEmpty(Convert.ToString(formData["dienThoai"]))) { dienThoai = Convert.ToString(formData["dienThoai"]); }
                string trangThai = "";
                if (formData.Keys.Contains("trangThai") && !string.IsNullOrEmpty(Convert.ToString(formData["trangThai"]))) { trangThai = Convert.ToString(formData["trangThai"]); }
                DateTime? ngayDatHang = null;
                if (formData.Keys.Contains("ngayDatHang") && !string.IsNullOrEmpty(Convert.ToString(formData["ngayDatHang"]))) { ngayDatHang = DateTime.Parse(Convert.ToString(formData["ngayDatHang"])); }

                long total = 0;
                var data = _HoaDonBusiness.SearchHoaDon(pageIndex, pageSize, out total, maDonHang, hoTen, dienThoai, trangThai, ngayDatHang);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = pageIndex,
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
