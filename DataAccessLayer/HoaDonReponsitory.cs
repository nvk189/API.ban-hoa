using DataAccessLayer.Helper;
using DataAccessLayer.Helper.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HoaDonReponsitory:IHoaDonReponsitory
    {
        private IDatabaseHelper _helper;
        public HoaDonReponsitory (IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(HoaDonModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadon_create",
                "@HoTen", model.HoTen,
                "@DienThoai", model.DienThoai,
                "@DiaChi", model.DiaChi,
                "@NgayDatHang", model.NgayDatHang,
                "@NgayGiaoHang", model.NgayGiaoHang,
                "@TongTien", model.TongTien,
                "@TrangThai", model.TrangThai,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
               
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

        public HoaDonModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "hoadon_get_by_id",
                     "@MaHoaDon", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(HoaDonModel model)
        {
            string msgError = "";
            try
            {
                var result = _helper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoaDon_Update",
                "@MaDonHang",model.MaDonHang,
                "@HoTen", model.HoTen,
                "@DienThoai", model.DienThoai,
                "@DiaChi", model.DiaChi,
                "@NgayDatHang", model.NgayDatHang,
                "@NgayGiaoHang", model.NgayGiaoHang,
                "@TongTien", model.TongTien,
                "@TrangThai", model.TrangThai,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
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


        /// <summary>
        /// / lấy tất cả hóa đơn ngày hôm nay
        /// </summary>
        /// <returns></returns>
        public List<HoaDonModel> GetAll()
        {
            string msgError = "";

            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "GetHoaDonBy_GetDate");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HoaDonModel> SearchHoaDon(int pageIndex, int pageSize, out long total, int? maDonHang, string dienThoai, bool trangThai, DateTime? ngayDatHangStart, DateTime? ngayDatHangEnd)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "HoaDon_Search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@MaDonHang", maDonHang,
                    "@DienThoai", dienThoai,
                    "@TrangThai", trangThai,
                    "@NgayDatHangStart", ngayDatHangStart,
                    "@NgayDatHangEnd", ngayDatHangEnd);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public HoaDonModel Delete(int id)
        {
            string msgError = "";
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "xoa_hoadon",
                     "@mahd", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HoaDonModel> SearchHoaDon1(DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            string msgError = "";
           
            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "HoaDon_GetDate",

                    "@NgayDatHangStart", fr_NgayTao,
                    "@NgayDatHangEnd", to_NgayTao);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
             
                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
