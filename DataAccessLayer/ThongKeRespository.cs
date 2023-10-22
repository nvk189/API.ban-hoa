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
    public class ThongKeRespository:IThongKeRespository
    {
        private IDatabaseHelper _databaseHelper;
        public ThongKeRespository (IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public List<ThongKeModel> ThongKeHoaDon(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao, int LoaiThongKe)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "thongke_hoadon",
                        "@page_index", pageIndex,
                        "@page_size", pageSize,
                        "@fr_NgayTao", fr_NgayTao,
                        "@to_NgayTao", to_NgayTao,
                        "@LoaiThongKe", LoaiThongKe);


                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThongKeModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
