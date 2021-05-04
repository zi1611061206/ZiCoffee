using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Business;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.DAOs
{
    public class DiscountNoteImpl : IDiscountNote
    {
        #region Package_DiscountNoteImpl
        private static DiscountNoteImpl instance;

        public static DiscountNoteImpl Instance
        {
            get { if (instance == null) instance = new DiscountNoteImpl(); return instance; }
            private set { instance = value; }
        }

        private DiscountNoteImpl() { }
        #endregion

        public bool AddDiscountNote(DiscountNote note)
        {
            string query = "insert into PhieuGiamGia(MaChuongTrinh, TrangThai) values( @MaChuongTrinh , @TrangThai )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { note.ProgramId, note.Status });
            return result > 0;
        }

        public DataTable GetAllDiscountNote()
        {
            string query = "select * from PhieuGiamGia";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DiscountNote GetDiscountNoteById(int noteId)
        {
            string query = "select * from PhieuGiamGia where MaPhieu = " + noteId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new DiscountNote(data.Rows[0]);
        }

        public DataTable GetAllDiscountNoteByProgram(int programId)
        {
            string query = "select * from PhieuGiamGia where MaChuongTrinh = " + programId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllDiscountNoteByStatus(DiscountNoteStatus status)
        {
            string query = "select * from PhieuGiamGia where TrangThai = " + status;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateDiscountNote(DiscountNote note)
        {
            string query = "update PhieuGiamGia set " +
                "MaChuongTrinh = @MaChuongTrinh , " +
                "TrangThai = @TrangThai " +
                "where MaPhieu = " + note.DiscountNoteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                note.ProgramId,
                note.Status
            });
            return result > 0;
        }

        public bool DeleteAllDiscountNote()
        {
            string query = "delete from PhieuGiamGia";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteDiscountNoteById(int noteId)
        {
            string query = "delete from PhieuGiamGia where MaPhieu = " + noteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllDiscountNoteByStatus(DiscountNoteStatus status)
        {
            string query = "delete from PhieuGiamGia where TrangThai = " + status;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllDiscountNoteOfProgram(int programId)
        {
            string query = "delete from PhieuGiamGia where MaChuongTrinh = " + programId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllDiscountNote()
        {
            string query = "select count(*) from PhieuGiamGia";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchDiscountNote(int noteId)
        {
            throw new NotImplementedException();
        }
    }
}
