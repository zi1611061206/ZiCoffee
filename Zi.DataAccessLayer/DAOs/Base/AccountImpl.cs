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
    public class AccountImpl : IAccount
    {
        #region package_AccountImpl
        private static AccountImpl instance;
        public static AccountImpl Instance
        {
            get { if (instance == null) instance = new AccountImpl(); return instance; }
            private set { instance = value; }
        }
        private AccountImpl() { }
        #endregion

        #region CREATE
        public bool AddAccount(Account account)
        {
            string query = "insert into TaiKhoan(TenDangNhap, MaNhanVien)" +
                " values ('" + account.Username + "'," + account.EmployeeId + ")";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion

        #region READ
        public DataTable GetAllAccount()
        {
            string query = "select * from TaiKhoan";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Account GetAccountByUsername(string username)
        {
            string query = "select * from TaiKhoan where TenDangNhap = '" + username + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Account(data.Rows[0]);
        }

        public DataTable GetAccountOfEmployee(int employeeId)
        {
            string query = "select * from TaiKhoan where MaNhanVien = " + employeeId;
            return DataProvider.Instance.ExecuteQuery(query);
        }
        #endregion

        #region UPDATE
        public bool UpdatePassword(string username, string newPassword)
        {
            string query = "update TaiKhoan set MatKhau = '" + newPassword + "' where TenDangNhap = '" + username + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion

        #region DELETE
        public bool DeleteAllAccount()
        {
            string query = "delete from TaiKhoan";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccountByUsername(string username)
        {
            string query = "delete from TaiKhoan where TenDangNhap = '" + username + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllAccountOfEmployee(int employeeId)
        {
            string query = "delete from TaiKhoan where MaNhanVien = " + employeeId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion

        #region CHECKER
        public bool CheckAccount(string username)
        {
            string query = "select * from TaiKhoan where TenDangNhap = '" + username + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public bool CheckPassword(string username, string password)
        {
            string query = "select * from TaiKhoan where TenDangNhap = '" + username + "'and MatKhau = '"+ password +"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }
        #endregion

        #region OTHER
        public int CountAllAccount()
        {
            string query = "select count(*) from TaiKhoan";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchAccount(string username)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
