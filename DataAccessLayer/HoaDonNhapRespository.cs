using DataAccessLayer.Helper;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static DataModel.ThongkeModel;

namespace DataAccessLayer
{
    public  class HoaDonNhapRespository:IHoaDonNhapRespository
    {
        private IDatabaseHelper _helper;
        public HoaDonNhapRespository (IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonnhap_create",
                "@MaNhaCungCap", model.MaNhaCungCap,
                "@NgayNhap", model.NgayNhap,
                "@TongTien", model.TongTien,
                "@MaTaiKhoan", model.MaTaiKhoan,

                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
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

        public List<HoaDonNhapModel> GetAll()
        {
            string msgError = "";

            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "GetAllNhap"

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

        public HoaDonNhapModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "dhnhap_get_by_id",
                     "@mahdn", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<HoaDonNhapModel> SearchHoaDonNhap(int pageIndex, int pageSize, out long total, int? maHoaDonNhap, int? maNhaCungCap, DateTime? ngayNhapStart, DateTime? ngayNhapEnd, int? maTaiKhoan)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "Search_hoadonnhap",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@MaHoaDonNhap", maHoaDonNhap,
                    "@MaNhaCungCap", maNhaCungCap,
                    "@NgayNhapStart", ngayNhapStart,
                    "@NgayNhapEnd", ngayNhapEnd,
                    "@MaTaiKhoan", maTaiKhoan);

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                if (dt.Rows.Count > 0)
                    total = (long)dt.Rows[0]["RecordCount"];

                return dt.ConvertTo<HoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoaDonNhap_Update",
                "@MaHoaDonNhap", model.MaHoaDonNhap,
                "@MaNhaCungCap", model.MaNhaCungCap,
                "@NgayNhap", model.NgayNhap,
                "@TongTien", model.TongTien,
                "@MaTaiKhoan", model.MaTaiKhoan,

                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
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
