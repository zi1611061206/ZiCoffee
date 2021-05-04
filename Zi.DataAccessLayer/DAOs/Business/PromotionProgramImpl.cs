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
    public class PromotionProgramImpl : IPromotionProgram
    {
        #region package_PromotionProgramImpl
        private static PromotionProgramImpl instance;

        public static PromotionProgramImpl Instance
        {
            get { if (instance == null) instance = new PromotionProgramImpl(); return instance; }
            private set { instance = value; }
        }
        private PromotionProgramImpl() { }
        #endregion

        public bool AddPromotionProgram(PromotionProgram program)
        {
            string query = "insert into ChuongTrinhGiamGia(NoiDung, GiaTri, NgayBatDau, NgayKetThuc, DieuKienToiThieu, MaLoai) " +
                "values( @NoiDung , @GiaTri , @NgayBatDau , @NgayKetThuc , @DieuKienToiThieu , @MaLoai )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            {
                program.Content,
                program.Value,
                program.StartDate,
                program.EndDate,
                program.MinimumCondition,
                program.TypeId 
            });
            return result > 0;
        }

        public DataTable GetAllPromotionProgram()
        {
            string query = "select * from ChuongTrinhGiamGia";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public PromotionProgram GetPromotionProgramById(int programId)
        {
            string query = "select * from ChuongTrinhGiamGia where MaChuongTrinh = " + programId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new PromotionProgram(data.Rows[0]);
        }

        public DataTable GetAllPromotionProgramByCreatedDate(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllPromotionProgramByStartTime(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllPromotionProgramByEndTime(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllPromotionProgramOfType(int typeId)
        {
            string query = "select * from ChuongTrinhGiamGia where Maloai = " + typeId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdatePromotionProgram(PromotionProgram program)
        {
            string query = "update ChuongTrinhGiamGia set " +
                "NoiDung = @NoiDung , " +
                "GiaTri = @GiaTri , " +
                "NgayBatDau = @NgayBatDau , " +
                "NgayKetThuc = @NgayKetThuc , " +
                "DieuKienToiThieu = @DieuKienToiThieu , " +
                "MaLoai = @MaLoai " +
                "where MaChuongTrinh = " + program.PromotionProgramId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                program.Content,
                program.Value,
                program.StartDate,
                program.EndDate,
                program.MinimumCondition,
                program.TypeId
            });
            return result > 0;
        }

        public bool DeleteAllPromotionProgram()
        {
            string query = "delete from ChuongTrinhGiamGia";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeletePromotionProgramById(int programId)
        {
            string query = "delete from ChuongTrinhGiamGia where MaChuongTrinh = " + programId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllPromotionProgramOfType(int typeId)
        {
            string query = "delete from ChuongTrinhGiamGia where MaLoai = " + typeId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllPromotionProgram()
        {
            string query = "select count(*) from ChuongTrinhGiamGia";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchPromotionProgram(int programId)
        {
            throw new NotImplementedException();
        }
    }
}
