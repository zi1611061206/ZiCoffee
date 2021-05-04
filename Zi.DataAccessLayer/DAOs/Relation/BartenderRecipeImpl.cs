using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Relation;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.DAOs
{
    public class BartenderRecipeImpl : IBartenderRecipe
    {
        #region Package_BartenderRecipeImpl
        private static BartenderRecipeImpl instance;

        public static BartenderRecipeImpl Instance
        {
            get { if (instance == null) instance = new BartenderRecipeImpl(); return instance; }
            private set { instance = value; }
        }

        private BartenderRecipeImpl() { }
        #endregion

        public bool AddBartenderRecipe(BartenderRecipe recipe)
        {
            string query = "insert into CongThucPhaChe(MaDichVu, MaNguyenLieu, SoLuongPha) " +
                "values( @MaDichVu , @MaNguyenLieu , @SoLuongPha )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            {
                recipe.ServiceId,
                recipe.MaterialId,
                recipe.Quantity 
            });
            return result > 0;
        }

        public DataTable GetAllBartenderRecipe()
        {
            string query = "select * from CongThucPhaChe";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllBartenderRecipeOfService(int serviceId)
        {
            string query = "select * from CongThucPhaChe where MaDichVu = " + serviceId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllBartenderRecipeOfMaterial(int materialId)
        {
            string query = "select * from CongThucPhaChe where MaNguyenLieu = " + materialId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateBartenderRecipeQty(BartenderRecipe recipe)
        {
            string query = "update CongThucPhaChe set " +
                "SoLuongPha = @SoLuongPha " +
                "where MaDichVu = @MaDichVu and MaNguyenLieu = @MaNguyenLieu ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                recipe.Quantity,
                recipe.ServiceId,
                recipe.MaterialId
            });
            return result > 0;
        }

        public bool DeleteAllBartenderRecipe()
        {
            string query = "delete from CongThucPhaChe";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteBartenderRecipeById(int serviceId, int materialId)
        {
            string query = "delete from CongThucPhaChe where MaDichVu = @MaDichVu and MaNguyenLieu = @MaNguyenLieu ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            {
                serviceId, materialId
            });
            return result > 0;
        }

        public bool DeleteAllBartenderRecipeOfService(int serviceId)
        {
            string query = "delete from CongThucPhaChe where MaDichVu = " + serviceId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllBartenderRecipeOfMaterial(int materialId)
        {
            string query = "delete from CongThucPhaChe where MaNguyenLieu = " + materialId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllBartenderRecipe()
        {
            string query = "select count(*) from CongThucPhaChe";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
    }
}
