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

        public List<SanPhamModel1> Thongkedoanhthu(DateTime fr_NgayTao, DateTime to_NgayTao)
        {
            string msgError = "";
           
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "thongke",
                        "@fr_NgayTao", fr_NgayTao,
                        "@To_NgayTao", to_NgayTao
                      );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel1>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

      

        public List<HoaDonModel> ThongkeHoaDonBan(DateTime fr_NgayTao, DateTime to_NgayTao)
        {
            string msgError = "";

            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoadon_search2",
                        "@fr_NgayTao", fr_NgayTao,
                        "@to_NgayTao", to_NgayTao
                      );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HoaDonNhapModel> ThongkeHoaDonNhap(DateTime fr_NgayTao, DateTime to_NgayTao)
        {
            string msgError = "";

            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoadonnhap_search2",
                        "@fr_NgayTao", fr_NgayTao,
                        "@to_NgayTao", to_NgayTao
                      );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel1> ThongkeSanPham(int id)
        {
            string msgError = "";

            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "thongke_SanPham",
                    "@RequestType", id

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel1>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
