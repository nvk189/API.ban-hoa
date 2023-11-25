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
    public class SanPhamRepository:ISanPhamRepository
    {
        private IDatabaseHelper _dbhelper;
        public SanPhamRepository (IDatabaseHelper dbhelper)
        {
            _dbhelper = dbhelper;
        }

        public bool Create(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbhelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sanpham_create",
                "@MaChuyenMuc", model.MaChuyenMuc,
                "@TenSanPham", model.TenSanPham,
                "@MoTa", model.MoTa,
                "@AnhDaiDien", model.AnhDaiDien,
                "@Gia", model.Gia,
                "@GiaGiam", model.GiaGiam,
                "@SoLuong", model.SoLuong,
                "@TrangThai", model.TrangThai,
                "@LuotXem", model.LuotXem,
                "@DacBiet", model.DacBiet,
                "@list_json_chitietsanpham", model.list_json_chitietsanpham != null ? MessageConvert.SerializeObject(model.list_json_chitietsanpham) : null);
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

       

        public List<SanPhamModel> GetAll()
        {

            string msgError = "";

            try
            {
                var dt = _dbhelper.ExecuteSProcedureReturnDataTable(out msgError, "sanpham_by_all"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPhamModel GetByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbhelper.ExecuteSProcedureReturnDataTable(out msgError, "sanpham_get_by_id",
                     "@MaSanPham", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public bool Update(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbhelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sanpham_update",
                "MaSanPham",model.MaSanPham,
                "@MaChuyenMuc", model.MaChuyenMuc,
                "@TenSanPham", model.TenSanPham,
                "@MoTa", model.MoTa,
                "@AnhDaiDien", model.AnhDaiDien,
                "@Gia", model.Gia,
                "@GiaGiam", model.GiaGiam,
                "@SoLuong", model.SoLuong,
                "@TrangThai", model.TrangThai,
                "@LuotXem", model.LuotXem,
                "@DacBiet", model.DacBiet,
                "@list_json_chitietsanpham", model.list_json_chitietsanpham != null ? MessageConvert.SerializeObject(model.list_json_chitietsanpham) : null);
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
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, int maSanPham, string tenSanPham, int maChuyenMuc, bool trangThai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbhelper.ExecuteSProcedureReturnDataTable(out msgError, "sanpham_search",
                        "@page_index", pageIndex,
                        "@page_size", pageSize,
                        "@MaSanPham", maSanPham,
                        "@TenSanPham", tenSanPham,
                        "@MaChuyenMuc", maChuyenMuc,
                        "@TrangThai", trangThai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPhamModel Delete(int id)
        {
            string msgError = "Xóa thành công";
            try
            {
                var dt = _dbhelper.ExecuteSProcedureReturnDataTable(out msgError, "xoa_sanpham",
                     "@masp", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPhamModel1> chuyenmuc_sp(int chuyenMuc)
        {
            string msgError = "";

            try
            {
                var dt = _dbhelper.ExecuteSProcedureReturnDataTable(out msgError, "get_sp_maloai",
                    "@maloai",chuyenMuc

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
