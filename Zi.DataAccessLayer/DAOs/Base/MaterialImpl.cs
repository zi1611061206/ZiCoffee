using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Base;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.DAOs
{
    public class MaterialImpl : IMaterial
    {
        #region package_MaterialImpl
        private static MaterialImpl instance;

        public static MaterialImpl Instance
        {
            get { if (instance == null) instance = new MaterialImpl(); return instance; }
            private set { instance = value; }
        }

        private MaterialImpl() { }
        #endregion

        public bool AddMaterial(Material material)
        {
            string query = "insert into NguyenLieu(TenNguyenLieu, SoLuongTon, DonViTinh)" +
                " values (N'@TenNguyenLieu', @SoLuongTon, N'@DonViTinh')";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            { 
                material.MaterialName, 
                material.StockAmount, 
                material.Unit 
            });
            return result > 0;
        }

        public DataTable GetAllMaterial()
        {
            string query = "select * from NguyenLieu";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Material GetMaterialById(int materialId)
        {
            string query = "select * from NguyenLieu where MaNguyenLieu = " + materialId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Material(data.Rows[0]);
        }

        public bool UpdateMaterial(Material material)
        {
            string query = "update NguyenLieu set " +
                "TenNguyenLieu = N'@TenNguyenLieu', " +
                "SoLuongTon = @SoLuongTon, " +
                "DonViTinh = N'@DonViTinh' " +
                "where MaNguyenLieu = " + material.MaterialId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            { 
                material.MaterialName, 
                material.StockAmount, 
                material.Unit 
            });
            return result > 0;
        }

        public bool DeleteAllMaterial()
        {
            string query = "delete from NguyenLieu";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMaterialById(int materialId)
        {
            string query = "delete from NguyenLieu where MaNguyenLieu = " + materialId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckMaterialName(string materialName)
        {
            string query = "select * from NguyenLieu where TenNguyenLieu = N'" + materialName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllMaterial()
        {
            string query = "select count(*) from NguyenLieu";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchMaterial(string materialName)
        {
            throw new NotImplementedException();
        }
    }
}
