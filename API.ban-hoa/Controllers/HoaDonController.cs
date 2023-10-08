﻿using BusinessLogicLayer;
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

        [Route("searchHoaDon")]
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
