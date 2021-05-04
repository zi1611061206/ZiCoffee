using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Base;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.DAOs
{
    public class TableImpl : ITable
    {
        #region Package_TableImpl
        private static TableImpl instance;

        public static TableImpl Instance
        {
            get { if (instance == null) instance = new TableImpl(); return instance; }
            private set { instance = value; }
        }

        private TableImpl() { }
        #endregion

        public bool AddTable(Table table)
        {
            string query = "insert into Ban(MaKhuVuc, TenBan, TrangThaiSuDung) " +
                           "values (@MaKhuVuc, N'@TenBan', @TrangThaiSuDung)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                table.AreaId,
                table.TableName,
                table.UsedStatus
            });
            return result > 0;
        }

        public DataTable GetAllTable()
        {
            string query = "select * from Ban";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Table GetTableById(int tableId)
        {
            string query = "select * from Ban where MaBan = " + tableId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Table(data.Rows[0]);
        }

        public DataTable GetAllTableByStatus(TableStatus status)
        {
            string query = "select * from Ban where TrangThaiSuDung = " + status;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllTableOfArea(int areaId)
        {
            string query = "select * from Ban where MaKhuVuc = " + areaId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateTable(Table table)
        {
            string query = "update Ban set " +
                "MaKhuVuc = @MaKhuvuc, " +
                "TenBan = N'@TenBan', " +
                "TrangThaiSuDung = @TrangThaiSuDung " +
                "where MaBan = " + table.TableId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                table.AreaId, 
                table.TableName, 
                table.UsedStatus
            });
            return result > 0;
        }

        public bool DeleteAllTable()
        {
            string query = "delete from Ban";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTableById(int tableId)
        {
            string query = "delete from Ban where MaBan = " + tableId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllTableByStatus(TableStatus status)
        {
            string query = "delete from Ban where TrangThaiSuDung = " + status;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllTableOfArea(int areaId)
        {
            string query = "delete from Ban where MaKhuVuc = " + areaId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckTableAndArea(int areaId, string tableName)
        {
            string query = "select * from Ban where TenBan = N'" + tableName + "' and MakhuVuc = " + areaId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllTable()
        {
            string query = "select count(*) from Ban";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public int CountAllTableByStatus(TableStatus status)
        {
            string query = "select count(*) from Ban where TrangThaiSuDung = " + (int)status;
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchTable(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
