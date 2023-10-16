using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataModel.ThongkeModel;

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
       
        [Route("search")]
        [HttpPost]
        public IActionResult SearchHoaDon([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var pageIndex = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                int? maDonHang = null;
                if (formData.Keys.Contains("ma_don_hang") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_don_hang"])))
                {
                    maDonHang = int.Parse(Convert.ToString(formData["ma_don_hang"]));
                }

                string dienThoai = "";
                if (formData.Keys.Contains("dien_thoai") && !string.IsNullOrEmpty(Convert.ToString(formData["dien_thoai"])))
                {
                    dienThoai = Convert.ToString(formData["dien_thoai"]);
                }

                string trangThai = "";
                if (formData.Keys.Contains("trang_thai") && !string.IsNullOrEmpty(Convert.ToString(formData["trang_thai"])))
                {
                    trangThai = Convert.ToString(formData["trang_thai"]);
                }

                DateTime? ngayDatHangStart = null;
                if (formData.Keys.Contains("ngay_dat_hang_start") && !string.IsNullOrEmpty(Convert.ToString(formData["ngay_dat_hang_start"])))
                {
                    ngayDatHangStart = DateTime.Parse(Convert.ToString(formData["ngay_dat_hang_start"]));
                }

                DateTime? ngayDatHangEnd = null;
                if (formData.Keys.Contains("ngay_dat_hang_end") && !string.IsNullOrEmpty(Convert.ToString(formData["ngay_dat_hang_end"])))
                {
                    ngayDatHangEnd = DateTime.Parse(Convert.ToString(formData["ngay_dat_hang_end"]));
                }

                long total = 0;
                var data = _HoaDonBusiness.SearchHoaDon(pageIndex, pageSize, out total, maDonHang, dienThoai, trangThai, ngayDatHangStart, ngayDatHangEnd);
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


        [Route("ThongKe")]
        [HttpPost]
        public IActionResult SearchHoaDon1([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                DateTime? fr_NgayTao = null;
                if (formData.Keys.Contains("fr_NgayTao") && formData["fr_NgayTao"] != null && formData["fr_NgayTao"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayTao"].ToString());
                    fr_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayTao = null;
                if (formData.Keys.Contains("to_NgayTao") && formData["to_NgayTao"] != null && formData["to_NgayTao"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayTao"].ToString());
                    to_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _HoaDonBusiness.SearchHoaDon1(page, pageSize, out total, fr_NgayTao, to_NgayTao);
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
