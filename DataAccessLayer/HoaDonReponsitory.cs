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

        public List<HoaDonModel1> GetAll()
        {
            string msgError = "";

            try
            {
                var dt = _helper.ExecuteSProcedureReturnDataTable(out msgError, "GetHoaDonBy_GetDate");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<HoaDonModel1>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
