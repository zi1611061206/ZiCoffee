using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class Account
    {
        private string username;
        private int employeeId;
        private DateTime createdDate;
        private string password;

        public string Username { get => username; set => username = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public string Password { set => password = value; }

        public Account(string username, int employeeId, DateTime createdDate, string password)
        {
            Username = username;
            EmployeeId = employeeId;
            CreatedDate = createdDate;
            Password = password;
        }

        public Account(DataRow row)
        {
            Username = row["TenDangNhap"].ToString();
            EmployeeId = (int)row["MaNhanVien"];
            DateTime result;
            if (DateTime.TryParse(row["NgayLap"].ToString(), out result))
                CreatedDate = result;
            Password = row["MatKhau"].ToString();
        }
    }
}
