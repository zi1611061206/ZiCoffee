using DataTransferLayer.Enums;
using System;
using System.Data;

namespace Zi.DataTransferLayer.DTOs
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeePhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Sex { get; set; }
        public string CitizenId { get; set; }
        public byte[] Avatar { get; set; }
        public int PositionId { get; set; }

        public string FullInfo { get { return $"{EmployeeId} - {FirstName} {MiddleName} {LastName} - {CitizenId}"; } }

        public Employee(int employeeId, string firstName, string middleName, string lastName, string employeeAddress, string employeePhone, DateTime dateOfBirth, GenderType sex, string citizenId, byte[] avatar, int positionId)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            EmployeeAddress = employeeAddress;
            EmployeePhone = employeePhone;
            DateOfBirth = dateOfBirth;
            Sex = sex;
            CitizenId = citizenId;
            Avatar = avatar;
            PositionId = positionId;
        }

        public Employee(DataRow row)
        {
            EmployeeId = (int)row["MaNhanVien"];
            FirstName = row["Ho"].ToString();
            MiddleName = row["TenDem"].ToString();
            LastName = row["Ten"].ToString();
            EmployeeAddress = row["DiaChi"].ToString();
            EmployeePhone = row["SoDienThoai"].ToString();
            if (DateTime.TryParse(row["NgaySinh"].ToString(), out DateTime result))
            {
                DateOfBirth = result;
            }
            int gender = Convert.ToInt32(row["GioiTinh"]);
            Sex = (GenderType)gender;
            CitizenId = row["ChungMinhNhanDan"].ToString();
            Avatar = (byte[])row["AnhDaiDien"];
            PositionId = (int)row["MaChucVu"];
        }
    }
}
