using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public  class TaiKhoanBusiness:ITaiKhoanBusiness
    {
        private ITaiKhoanRepository _res;
        private string secret;
        public TaiKhoanBusiness(ITaiKhoanRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

        public bool Create(TaiKhoanModel model)
        {
            return _res.Create(model);
        }

        public TaiKhoanModel1 Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<TaiKhoanModel> GetAll()
        {
            return _res.GetAll();
        }

        public TaiKhoanModel GetId(int id)
        {
           return _res.GetId(id);
        }

        public List<TaiKhoanModel> GetLoaiTaiKhoan(int loaiTaiKhoan)
        {
           return _res.GetLoaiTaiKhoan(loaiTaiKhoan);
        }

        public TaiKhoanModel1 Login(string taikhoan, string matkhau)
        {
            var user = _res.Login(taikhoan, matkhau);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.TenDangNhap.ToString()),
                    new Claim(ClaimTypes.Email, user.MatKhau)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }

        public bool Update_admin(TaiKhoanModel model)
        {
            return _res.Update_admin(model);
        }

        public bool Update_pass_user(ChiTietTaiKhoanModel model)
        {
            return _res.Update_pass_user(model);
        }

        public bool Update_tk_user(TaiKhoanModel model)
        {
            return _res.Update_tk_user(model);
        }
    }
}
