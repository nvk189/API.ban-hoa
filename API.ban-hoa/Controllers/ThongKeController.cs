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
        public ThongKeController (IThongKeBusinesscs thongKeBusinesscs)
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


        ////////// thống kê sản phẩm bán chạy, nhiều lượt xem ,mới nhập về
        [Route("get-id/ sanphamthongke")]
        [HttpGet]
        public List<SanPhamModel1> ThongKeSanPham(int id)
        {
            return _thongKeBusinesscs.ThongKeSanPham(id);
        }
    }
}
