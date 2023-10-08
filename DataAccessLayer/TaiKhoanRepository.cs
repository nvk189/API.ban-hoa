using DataAccessLayer.Helper;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TaiKhoanRepository:ITaiKhoanRepository
    {
        private IDatabaseHelper _database;
        public TaiKhoanRepository (IDatabaseHelper database)
        {
            _database = database;   
        }

        public TaiKhoanModel1 Login(string taikhoan, string matkhau)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@TenDangNhap", taikhoan,
                     "@MatKhau", matkhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoanModel1>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
