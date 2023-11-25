using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ban_hoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBusiness _business;
        public TaiKhoanController (ITaiKhoanBusiness business)
        {
            _business = business;   
        }
        [AllowAnonymous]
        [Route("get-all")]
        [HttpGet]
        public List<TaiKhoanModel> GetByAll()
        {
            return _business.GetAll();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _business.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.TenDangNhap, email = user.MatKhau, maloaitk = user.MaLoaiTaiKhoan, token = user.token });
        }
        [Route("get-id")]
        [HttpGet]
        public TaiKhoanModel GetByID(int id)
        {
            return _business.GetId(id);
        }

        [Route("get-loai_tai_khoan/{loaiTaiKhoan}")]
        [HttpGet]
        public List<TaiKhoanModel> Get_Loai_Tk(int loaiTaiKhoan)
        {
            return _business.GetLoaiTaiKhoan(loaiTaiKhoan);
        }
        [Route("update-admin")]
        [HttpPost]
        public TaiKhoanModel Update([FromBody] TaiKhoanModel model)
        {

            _business.Update_admin(model);
            return model;
        }
        //[Route("Delete")]
        //[HttpGet]
        //public TaiKhoanModel1 delete(int id)
        //{
        //    return _business.Delete(id);
        //}
    }
}
