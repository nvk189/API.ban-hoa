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
        public List<HoaDonModel> GetAll()
        {
            return _HoaDonBusiness.GetAll();
        }
        //[Route("get-search")]
        //[HttpPost]
        //public List<HoaDonModel> Getsearch(DateTime? fr_NgayTao, DateTime? to_NgayTao)
        //{
        //    return _HoaDonBusiness.SearchHoaDon1(fr_NgayTao, to_NgayTao);
        //}
        [Route("get-by-id/{id}")]
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

        [Route("Delete")]
        [HttpGet]
        public HoaDonModel Delete(int id)
        {
            return _HoaDonBusiness.Delete(id);
        }

        //[Route("tổng tiền theo ngày ")]
        //[HttpPost]
        //public IActionResult SearchHoaDon([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var pageIndex = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());


        //        DateTime? fr_NgayTao = null;
        //        if (formData.Keys.Contains("fr_NgayTao") && formData["fr_NgayTao"] != null && formData["fr_NgayTao"].ToString() != "")
        //        {
        //            var dt = Convert.ToDateTime(formData["fr_NgayTao"].ToString());
        //            fr_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        //        }


        //        DateTime? to_NgayTao = null;
        //        if (formData.Keys.Contains("to_NgayTao") && formData["to_NgayTao"] != null && formData["to_NgayTao"].ToString() != "")
        //        {
        //            var dt = Convert.ToDateTime(formData["NgayNhapEnd"].ToString());
        //            to_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        //        }

        //        long total = 0;
        //        var data = _HoaDonBusiness.SearchHoaDon1(pageIndex, pageSize, out total, fr_NgayTao, to_NgayTao);
        //        return Ok(
        //            new
        //            {
        //                TotalItems = total,
        //                Data = data,
        //                Page = pageIndex,
        //                PageSize = pageSize
        //            }
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        [Route("Search")]
        [HttpPost]
        public IActionResult SearchHoaDon1([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int maDonHang = 0;
                if (formData.Keys.Contains("maDonHang") && !string.IsNullOrEmpty(formData["maDonHang"].ToString()))
                {
                    if (int.TryParse(formData["maDonHang"].ToString(), out int maDonHangValue))
                    {
                        maDonHang = maDonHangValue;
                    }
                }
                string dienThoai = "";
                if (formData.Keys.Contains("dienThoai") && !string.IsNullOrEmpty(Convert.ToString(formData["dienThoai"])))
                {
                    dienThoai = Convert.ToString(formData["dienThoai"]);
                }
                bool trangThai = true;
                if (formData.Keys.Contains("trangThai"))
                {
                    if (bool.TryParse(formData["trangThai"].ToString(), out bool trangThaiValue))
                    {
                        trangThai = trangThaiValue;
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
                var data = _HoaDonBusiness.SearchHoaDon(page, pageSize, out total, maDonHang, dienThoai, trangThai, fr_NgayTao, to_NgayTao);
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

        [Route("GetSearch")]
        [HttpPost]
        public IActionResult GetSearch([FromBody] Dictionary<string, object> formData)
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

                var result = _HoaDonBusiness.SearchHoaDon1(fr_NgayTao, to_NgayTao);
                // Xử lý kết quả từ _HoaDonBusiness.SearchHoaDon1 ở đây
                // Ví dụ:
                // return Ok(result);
                // hoặc
                // return new { Data = result };

                // Thêm lệnh return để trả về kết quả hoặc giá trị phù hợp
                return Ok(result); // hoặc trả về giá trị mong muốn
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Trả về lỗi nếu có exception
            }
        }

    }
}
