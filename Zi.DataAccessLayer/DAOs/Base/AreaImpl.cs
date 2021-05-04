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
    public class AreaImpl : IArea
    {
        #region Package_AreaImpl
        private static AreaImpl instance;

        public static AreaImpl Instance
        {
            get { if (instance == null) instance = new AreaImpl(); return instance; }
            private set { instance = value; }
        }

        private AreaImpl() { }
        #endregion

        public bool AddArea(Area area)
        {
            string query = "insert into KhuVuc(TenKhuvuc) values (N'"+area.AreaName+"')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable GetAllArea()
        {
            string query = "select * from KhuVuc";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Area GetAreaById(int areaId)
        {
            string query = "select * from KhuVuc where MaKhuVuc = " + areaId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Area(data.Rows[0]);
        }

        public bool UpdateArea(Area area)
        {
            string query = "update KhuVuc set TenKhuVuc = N'" + area.AreaName + "' where MaKhuVuc = " + area.AreaId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllArea()
        {
            string query = "delete from KhuVuc";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAreaById(int areaId)
        {
            string query = "delete from KhuVuc where MaKhuVuc = " + areaId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckAreaName(string areaName)
        {
            string query = "select * from KhuVuc where TenKhuVuc = N'" + areaName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllArea()
        {
            string query = "select count(*) from KhuVuc";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchArea(string areaName)
        {
            throw new NotImplementedException();
        }
    }
}
