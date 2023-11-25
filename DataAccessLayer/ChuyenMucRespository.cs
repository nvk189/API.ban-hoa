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
    public class ChuyenMucRespository:IChuyenMucRespository
    {
        private IDatabaseHelper _helper;
        public ChuyenMucRespository (IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(ChuyenMucModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_chuyenmuc",
               "@TenChuyenMuc", model.TenChuyenMuc);

               
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

        public List<ChuyenMucModel> getAll()
        {
            string msgError = "";

            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "get_all");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<ChuyenMucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChuyenMucModel> Search(string tenchuyenmuc)
        {
            string msgError = "";
          
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "search_chuyenmuc",
                    "@TenChuyenMuc", tenchuyenmuc);
                   
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ChuyenMucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ChuyenMucModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_chuyenmuc",
                "@MaChuyenMuc", model.MaChuyenMuc,
               "@TenChuyenMuc", model.TenChuyenMuc);


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
