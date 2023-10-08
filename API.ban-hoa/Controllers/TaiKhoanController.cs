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
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _business.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.TenDangNhap, email = user.MatKhau, token = user.token });
        }
    }
}
