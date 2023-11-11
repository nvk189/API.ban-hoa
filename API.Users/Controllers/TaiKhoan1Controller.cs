using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoan1Controller : ControllerBase
    {
        private ITaiKhoanBusiness _business;
        public TaiKhoan1Controller(ITaiKhoanBusiness business)
        {
            _business = business;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _business.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.TenDangNhap, email = user.MatKhau, token = user.token });
        }

        [Route("create")]
        [HttpPost]
        public TaiKhoanModel CreateItem([FromBody] TaiKhoanModel model)
        {

            _business.Create(model);
            return model;
        }

        [Route("Hủy tài khoản")]
        [HttpGet]
        public TaiKhoanModel1 delete(int id)
        {
            return _business.Delete(id);
        }


    }
}
