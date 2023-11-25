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
    public class NhaCungCapRespository:INhaCungCapRespository
    {
        private IDatabaseHelper _helper;
        public NhaCungCapRespository (IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "NhaCungCap_create",

                "@TenNhaCungCap", model.TenNhaCungCap,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai,
                "@Email", model.Email);
               
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

        public List<NhaCungCapModel> GetAll()
        {
            string msgError = "";

            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "NhaCungCap_All");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<NhaCungCapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NhaCungCapModel GetByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "NhaCungCap_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaCungCapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "NhaCungCap_update",
                "@MaNhaCungCap", model.MaNhaCungCap,
                "@TenNhaCungCap", model.TenNhaCungCap,
                "@DiaChi", model.DiaChi,
                "@DienThoai", model.DienThoai,
                "@Email", model.Email);

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

        public List<NhaCungCapModel> SearchNhaCungCap(int pageIndex, int pageSize, out long total, string tenNhaCungCap)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "nhacungcap_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenNhaCungCap", tenNhaCungCap
                    //"@DiaChi", diaChi,
                    //"@DienThoai", dienThoai,
                    //"@Email", email
                    );

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                if (dt.Rows.Count > 0)
                    total = (long)dt.Rows[0]["RecordCount"];

                return dt.ConvertTo<NhaCungCapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
