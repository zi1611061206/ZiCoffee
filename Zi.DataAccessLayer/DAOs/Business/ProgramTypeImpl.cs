using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Business;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.DAOs
{
    public class ProgramTypeImpl : IProgramType
    {
        #region package_ProgramTypeImpl
        private static ProgramTypeImpl instance;

        public static ProgramTypeImpl Instance
        {
            get { if (instance == null) instance = new ProgramTypeImpl(); return instance; }
            private set { instance = value; }
        }
        private ProgramTypeImpl() { }
        #endregion

        public bool AddProgramType(ProgramType type)
        {
            string query = "insert into LoaiChuongTrinh(TenLoai) values( N'" + type.TypeName + "' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable GetAllProgramType()
        {
            string query = "select * from LoaiChuongTrinh";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public ProgramType GetProgramTypeById(int typeId)
        {
            string query = "select * from LoaiChuongTrinh where MaLoai = " + typeId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new ProgramType(data.Rows[0]);
        }

        public bool UpdateProgramType(ProgramType type)
        {
            string query = "update LoaiChuongTrinh set " +
                "TenLoai = @TenLoai " +
                "where MaLoai = " + type.TypeId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                type.TypeName
            });
            return result > 0;
        }

        public bool DeleteAllProgramType()
        {
            string query = "delete from LoaiChuongTrinh";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteProgramTypeById(int typeId)
        {
            string query = "delete from LoaiChuongTrinh where MaLoai = " + typeId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllProgramType()
        {
            string query = "select count(*) from LoaiChuongTrinh";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchProgramType(string typeName)
        {
            throw new NotImplementedException();
        }
    }
}
