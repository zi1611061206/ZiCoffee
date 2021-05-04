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
    public class PositionImpl : IPosition
    {
        #region package_PositionImpl
        private static PositionImpl instance;

        public static PositionImpl Instance
        {
            get { if (instance == null) instance = new PositionImpl(); return instance; }
            private set { instance = value; }
        }
        private PositionImpl() { }
        #endregion

        public bool AddPosition(Position position)
        {
            string query = "insert into ChucVu(TenChucVu) values (N'" + position.PositionName + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable GetAllPosition()
        {
            string query = "select * from ChucVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Position GetPositionById(int positionId)
        {
            string query = "select * from Chucvu where MaChucVu = " + positionId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Position(data.Rows[0]);
        }

        public bool UpdatePosition(Position position)
        {
            string query = "update ChucVu set TenChucVu = N'" + position.PositionName + "' where MaChucVu = " + position.PositionId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllPosition()
        {
            string query = "delete from ChucVu";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeletePositionById(int positionId)
        {
            string query = "delete from ChucVu where MaChucVu = " + positionId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckPositionName(string positionName)
        {
            string query = "select * from ChucVu where TenChucVu = N'" + positionName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllPosition()
        {
            string query = "select count(*) from ChucVu";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchPosition(string positionName)
        {
            throw new NotImplementedException();
        }
    }
}
