using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Base;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.DAOs
{
    public class ServiceImpl : IService
    {
        #region Package_ServiceImpl
        private static ServiceImpl instance;

        public static ServiceImpl Instance
        {
            get { if (instance == null) instance = new ServiceImpl(); return instance; }
            private set { instance = value; }
        }

        private ServiceImpl() { }
        #endregion

        public bool AddService(Service service)
        {
            string query = "insert into DichVu(MaDanhMuc, TenDichvu, HinhAnh, DonGia, TinhTrangSuDung, MoTa) " +
                           "values (@MaDanhMuc, N'@TenDichVu', @HinhAnh, @DonGia, @TinhTrangSuDung, N'@MoTa')";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                service.CategoryId,
                service.ServiceName,
                service.Image,
                service.Price,
                service.UsedStatus,
                service.Description
            });
            return result > 0;
        }

        public DataTable GetAllService()
        {
            string query = "select * from DichVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Service GetServiceById(int serviceId)
        {
            string query = "select * from DichVu where MaDichVu = " + serviceId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Service(data.Rows[0]);
        }

        public DataTable GetAllBillByStatus(ServiceStatus status)
        {
            string query = "select * from DichVu where TinhTrangSuDung = " + status;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllServiceOfCategory(int categoryId)
        {
            string query = "select * from DichVu where MaDanhMuc = " + categoryId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateService(Service service)
        {
            string query = "update DichVu set " +
                "MaDanhMuc = @MaDanhMuc, " +
                "TenDichVu = N'@TenDichVu', " +
                "HinhAnh = @HinhAnh, " +
                "DonGia = @DonGia, " +
                "TinhTrangSuDung = @TinhTrangSuDung, " +
                "MoTa = N'@MoTa' " +
                "where MaDichVu = " + service.ServiceId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                service.CategoryId, 
                service.ServiceName, 
                service.Image, 
                service.Price, 
                service.UsedStatus, 
                service.Description
            });
            return result > 0;
        }

        public bool DeleteAllService()
        {
            string query = "delete from DichVu";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteServiceById(int serviceId)
        {
            string query = "delete from DichVu where MaDichVu = " + serviceId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllServiceByStatus(ServiceStatus status)
        {
            string query = "delete from DichVu where TinhTrangSuDung = " + status;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllServiceOfCategory(int categoryId)
        {
            string query = "delete from DichVu where MaDanhMuc = " + categoryId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckServiceName(string serviceName)
        {
            string query = "select * from DichVu where TenDichVu = N'" + serviceName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllService()
        {
            string query = "select count(*) from DichVu";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public int CountAllServiceOfCategory(int categoryId)
        {
            string query = "select count(*) from DichVu where MaDanhMuc = " + categoryId;
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchService(string serviceName)
        {
            throw new NotImplementedException();
        }
    }
}
