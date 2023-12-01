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
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private IDatabaseHelper _database;
        public TaiKhoanRepository(IDatabaseHelper database)
        {
            _database = database;
        }

        public bool Create(TaiKhoanModel model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "taikhoan_create",
                "@TenDangNhap", model.TenDangNhap,
                "@MatKhau", model.MatKhau,
                "@MaLoaiTaiKhoan", model.MaLoaiTaiKhoan,
                "@TrangThai", model.TrangThai,
                "@list_json_chitiettaikhoan", model.list_json_chitiettaikhoan != null ? MessageConvert.SerializeObject(model.list_json_chitiettaikhoan) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaiKhoanModel1 Delete(int id)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "sp_delete_taikhoan", "@MaTaiKhoan", id
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

        public List<TaiKhoanModel> GetAll()
        {
            string msgError = "";

            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "GetAll"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TaiKhoanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaiKhoanModel GetId(int id)
        {
            string msgError = "";
            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "get_id_taikhoan",
                    "@id", id
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TaiKhoanModel> GetLoaiTaiKhoan(int loaiTaiKhoan)
        {
            string msgError = "";

            try
            {
                var dt = _database.ExecuteSProcedureReturnDataTable(out msgError, "get_loaiTK",
                    "@loaiTk", loaiTaiKhoan

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TaiKhoanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public bool Update_admin(TaiKhoanModel model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "update_tk_admin",
                    "@maTaiKhoan", model.MaTaiKhoan,
                    "@TrangThai", model.TrangThai,
                    "@MaLoaiTK", model.MaLoaiTaiKhoan);



                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_pass_user(ChiTietTaiKhoanModel model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "update_tk_user",
                    "@maLoaiTK", model.MaChiTietTaiKhoan,
                    "@hoten", model.HoTen,
                    "@email", model.Email,
                    "@dienthoai", model.DienThoai,
                    "@diachi", model.DiaChi);



                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tk_user(TaiKhoanModel model)
        {
            string msgError = "";
            try
            {
                var result = _database.ExecuteScalarSProcedureWithTransaction(out msgError, "update_tk_user_pass",
                    "@maTK", model.MaTaiKhoan,
                    "@matkhau", model.MatKhau);



                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}