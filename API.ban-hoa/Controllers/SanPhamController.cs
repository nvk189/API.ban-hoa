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

        //[Route("search")]
        //[HttpGet]
        //public IActionResult Search([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        int ma_sanpham;
        //        if (formData.Keys.Contains("ma_sanpham") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_sanpham"])))
        //        {
        //            ma_sanpham = Convert.ToInt32(formData["ma_sanpham"]);
        //        }

        //        string ten_sanpham = "";
        //        if (formData.Keys.Contains("ten_sanpham") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_sanpham"]))) { ten_sanpham = Convert.ToString(formData["ten_sanpham"]); }


        //        int ma_chuyen_muc;
        //        if (formData.Keys.Contains("ma_chuyen_muc") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_chuyen_muc"])))
        //        {
        //            ma_chuyen_muc = Convert.ToInt32(formData["ma_chuyen_muc"]);
        //        }


        //        bool trang_thai = false;
        //        if (formData.Keys.Contains("trang_thai"))
        //        {
        //            trang_thai = !string.IsNullOrEmpty(Convert.ToString(formData["trang_thai"]));
        //        }



        //        long total = 0;
        //        var data = _sanPhamBusiness.Search(page, pageSize, out total,  ma_sanpham, ten_sanpham, ma_chuyen_muc, trang_thai);
        //        return Ok(
        //            new
        //            {
        //                TotalItems = total,
        //                Data = data,
        //                Page = page,
        //                PageSize = pageSize,

        //            }
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

    }
}
