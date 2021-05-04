using DataTransferLayer.Enums;
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
    public class EmployeeImpl : IEmployee
    {
        #region package_EmployeeImpl
        private static EmployeeImpl instance;

        public static EmployeeImpl Instance
        {
            get { if (instance == null) instance = new EmployeeImpl(); return instance; }
            private set { instance = value; }
        }

        private EmployeeImpl() { }
        #endregion

        public bool AddEmployee(Employee employee)
        {
            string query = "insert into NhanVien(DiaChi, SoDienThoai, GioiTinh, NgaySinh, ChungMinhNhanDan, AnhDaiDien, MaChucVu, Ho, TenDem, Ten) " +
                           "values (N'@DiaChi', '@SoDienThoai', @GioiTinh, @NgaySinh, '@ChungMinhNhanDan', @AnhDaiDien, @MaChucVu, N'@Ho', N'@TenDem', N'@Ten')";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            { 
                employee.EmployeeAddress, 
                employee.EmployeePhone, 
                employee.Sex, 
                employee.DateOfBirth, 
                employee.CitizenId, 
                employee.Avatar, 
                employee.PositionId, 
                employee.FirstName, 
                employee.MiddleName,
                employee.LastName 
            });
            return result > 0;
        }

        public DataTable GetAllEmployee()
        {
            string query = "select * from NhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            string query = "select * from NhanVien where MaNhanVien = " + employeeId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Employee(data.Rows[0]);
        }

        public DataTable GetAllEmployeeOfPosition(int positionId)
        {
            string query = "select * from NhanVien where MaChucVu = " + positionId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllEmployeeOfGender(GenderType type)
        {
            string query = "select * from NhanVien where GioiTinh = " + (int)type;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateEmployee(Employee employee)
        {
            string query = "update NhanVien set " +
                "DiaChi = N'@DiaChi', " +
                "SoDienThoai = '@SoDienThoai', " +
                "GioiTinh = @Gioitinh, " +
                "NgaySinh = @NgaySinh, " +
                "ChungMinhNhanDan = '@ChungMinhNhanDan', " +
                "AnhDaiDien = @AnhDaiDien, " +
                "MaChucVu = @MaChucVu, " +
                "Ho = N'@Ho', " +
                "TenDem = N'TenDem', " +
                "Ten = N'Ten' " +
                "where MaNhanVien = " + employee.EmployeeId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                employee.EmployeeAddress,
                employee.EmployeePhone, 
                employee.Sex, 
                employee.DateOfBirth, 
                employee.CitizenId, 
                employee.Avatar, 
                employee.PositionId, 
                employee.FirstName, 
                employee.MiddleName,
                employee.LastName
            });
            return result > 0;
        }

        public bool DeleteAllEmployee()
        {
            string query = "delete from NhanVien";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteEmployeeById(int employeeId)
        {
            string query = "delete from NhanVien where MaNhanVien = " + employeeId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllEmployeeOfPosition(int positionId)
        {
            string query = "delete from NhanVien where MaChucVu = " + positionId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllEmployeeOfGender(GenderType type)
        {
            string query = "delete from NhanVien where GioiTinh = " + (int)type;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckCitizenId(string citizenId)
        {
            string query = "select * from NhanVien where ChungMinhNhanDan = '" + citizenId + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllEmployee()
        {
            string query = "select count(*) from NhanVien";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchEmployee(string fName, string mName, string lName)
        {
            throw new NotImplementedException();
        }
    }
}
