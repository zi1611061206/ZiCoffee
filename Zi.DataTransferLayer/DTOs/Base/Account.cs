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
        public string Username { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Password { get; set; }

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
            if (DateTime.TryParse(row["NgayLap"].ToString(), out DateTime result))
            {
                CreatedDate = result;
            }
            Password = row["MatKhau"].ToString();
        }
    }
}
