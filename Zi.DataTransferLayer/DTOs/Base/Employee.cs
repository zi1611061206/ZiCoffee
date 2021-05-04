using DataTransferLayer.Enums;
using System;
using System.Data;

namespace Zi.DataTransferLayer.DTOs
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string middleName;
        private string lastName;
        private string employeeAddress;
        private string employeePhone;
        private DateTime dateOfBirth;
        private GenderType sex;
        private string citizenId;
        private byte[] avatar;
        private int positionId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string EmployeeAddress { get => employeeAddress; set => employeeAddress = value; }
        public string EmployeePhone { get => employeePhone; set => employeePhone = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public GenderType Sex { get => sex; set => sex = value; }
        public string CitizenId { get => citizenId; set => citizenId = value; }
        public byte[] Avatar { get => avatar; set => avatar = value; }
        public int PositionId { get => positionId; set => positionId = value; }

        public string fullInfo => $"{employeeId} - {firstName} {middleName} {lastName} - {citizenId}";

        public Employee(int employeeId, string firstName, string middleName, string lastName, string employeeAddress, string employeePhone, DateTime dateOfBirth, GenderType sex, string citizenId, byte[] avatar, int positionId)
        {
            this.EmployeeId = employeeId;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.EmployeeAddress = employeeAddress;
            this.EmployeePhone = employeePhone;
            this.DateOfBirth = dateOfBirth;
            this.Sex = sex;
            this.CitizenId = citizenId;
            this.Avatar = avatar;
            this.PositionId = positionId;
        }

        public Employee(DataRow row)
        {
            EmployeeId = (int)row["MaNhanVien"];
            FirstName = row["Ho"].ToString();
            MiddleName = row["TenDem"].ToString();
            LastName = row["Ten"].ToString();
            EmployeeAddress = row["DiaChi"].ToString();
            EmployeePhone = row["SoDienThoai"].ToString();
            DateTime result;
            if (DateTime.TryParse(row["NgaySinh"].ToString(), out result))
                DateOfBirth = result;
            int gender = Convert.ToInt32(row["GioiTinh"]);
            Sex = (GenderType) gender;
            CitizenId = row["ChungMinhNhanDan"].ToString();
            Avatar = (byte[])row["AnhDaiDien"];
            PositionId = (int)row["MaChucVu"];
        }
    }
}
