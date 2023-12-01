using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : ControllerBase
    {
        private IThongKeBusinesscs _thongKeBusinesscs;
        public ThongKeController(IThongKeBusinesscs thongKeBusinesscs)
        {
            _thongKeBusinesscs = thongKeBusinesscs;
        }
        [Route("ThongKeHoaDon")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int LoaiThongKe = 0;
                if (formData.Keys.Contains("LoaiThongKe") && !string.IsNullOrEmpty(formData["LoaiThongKe"].ToString()))
                {
                    if (int.TryParse(formData["LoaiThongKe"].ToString(), out int LoaiThongKeValue))
                    {
                        LoaiThongKe = LoaiThongKeValue;
                    }
                }
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
                var data = _thongKeBusinesscs.ThongKeHoaDon(page, pageSize, out total, fr_NgayTao, to_NgayTao, LoaiThongKe);
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


        ////////// thống kê sản phẩm bán chạy, nhiều lượt xem ,mới nhập về, giảm giá 
        [Route("sanphamthongke")]
        [HttpGet]
        public List<SanPhamModel1> ThongKeSanPham(int id)
        {
            return _thongKeBusinesscs.ThongKeSanPham(id);
        }

        // thống kê doanh thu 
        [Route("thống kê doanh thu")]
        [HttpPost]
        public IActionResult DoanhThu([FromBody] Dictionary<string, object> formData)
        {
            try
            {
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
                var data = _thongKeBusinesscs.Thongkedoanhthu((DateTime)fr_NgayTao, (DateTime)to_NgayTao);
                return Ok(
                    new
                    {

                        Data = data,
                        Fr_NgayTao = fr_NgayTao,
                        to_NgayTao = to_NgayTao
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // thống kê hóa đơn bán
        [Route("thống kê hóa đơn bán")]
        [HttpPost]
        public IActionResult TKHoaDonBan([FromBody] Dictionary<string, object> formData)
        {
            try
            {
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
                var data = _thongKeBusinesscs.ThongkeHoaDonBan((DateTime)fr_NgayTao, (DateTime)to_NgayTao);
                return Ok(
                    new
                    {

                        Data = data,
                        Fr_NgayTao = fr_NgayTao,
                        to_NgayTao = to_NgayTao
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("thống kê hóa đơn nhập")]
        [HttpPost]
        public IActionResult TKHoaDonBanNhap([FromBody] Dictionary<string, object> formData)
        {
            try
            {
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
                var data = _thongKeBusinesscs.ThongkeHoaDonNhap((DateTime)fr_NgayTao, (DateTime)to_NgayTao);
                return Ok(
                    new
                    {

                        Data = data,
                        Fr_NgayTao = fr_NgayTao,
                        to_NgayTao = to_NgayTao
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
