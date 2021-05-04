using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface IAccount
    {
        /// <summary>
        /// Thêm một tài khoản
        /// </summary>
        /// <param name="account"></param>
        /// <returns>
        /// true: thành công, false: thất bại
        /// </returns>
        bool AddAccount(Account account);

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns>DataTable</returns>
        DataTable GetAllAccount();

        /// <summary>
        /// Lấy tài khoản theo tên đăng nhập
        /// </summary>
        /// <param name="username"></param>
        /// <returns>DataTable</returns>
        Account GetAccountByUsername(string username);

        /// <summary>
        /// Lấy tài khoản theo mã nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>DataTable</returns>
        DataTable GetAccountOfEmployee(int employeeId);

        /// <summary>
        /// Cập nhật hoặc đặt lại mật khẩu
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>
        /// true: thành công, false: thất bại
        /// </returns>
        bool UpdatePassword(string username, string newPassword);

        /// <summary>
        /// Xóa toàn bộ tài khoản
        /// </summary>
        /// <returns>
        /// true: thành công, false thất bại
        /// </returns>
        bool DeleteAllAccount();

        /// <summary>
        /// Xóa tài khoản theo tên đăng nhập
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// true: thành công, false: thất bại
        /// </returns>
        bool DeleteAccountByUsername(string username);

        /// <summary>
        /// Xóa tất cả tài khoản của một nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        bool DeleteAllAccountOfEmployee(int employeeId);

        /// <summary>
        /// Kiểm tra tài khoản đã tồn tại hay chưa
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// true: đã tồn tại, false: chưa tồn tại
        /// </returns>
        bool CheckAccount(string username);

        /// <summary>
        /// Kiểm tra mật khẩu hiện tại
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// true: hợp lệ, false: không hợp lệ
        /// </returns>
        bool CheckPassword(string username, string password);

        /// <summary>
        /// Đếm số tài khoản hiện có
        /// </summary>
        /// <returns>int</returns>
        int CountAllAccount();

        /// <summary>
        /// Tìm kiếm tài khoản theo tên đăng nhập
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        DataTable SearchAccount(string username);
    }
}
