using DataAccessLayer.Helper;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KhachHangReponsitory : IKhachHangRepository
    {

        private IDatabaseHelper _databaseHelper;
        public KhachHangReponsitory (IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public bool Create(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "khachhang_create",
               
                "@HoTen", model.HoTen,
                "@GioiTinh", model.GioiTinh,
                "@Email", model.Email,
                "@DienThoai", model.DienThoai,
                "@DiaChi", model.DiaChi);
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

      

        public List<KhachHangModel> GetAll()
        {
            string msgError = "";
           
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "khachhang_by_all");
                    
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
              
                return dt.ConvertTo<KhachHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public KhachHangModel GetByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "khachhang_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string ten_khach)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "khachhang_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Search", ten_khach
                    //"@DiaChi", dia_chi,
                    //"DienThoai", dien_Thoai,
                    //"GioiTinh", gioi_Tinh
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KhachHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "khachhang_update",
                "@MaKhachHang", model.MaKhachHang,
                "@HoTen", model.HoTen,
                 "@GioiTinh", model.GioiTinh,
                "@Email", model.Email,
                "@DienThoai", model.DienThoai,
                "@DiaChi", model.DiaChi);
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

        public bool Delete (KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "khachhang_delete",
                "@id", model.MaKhachHang);
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
