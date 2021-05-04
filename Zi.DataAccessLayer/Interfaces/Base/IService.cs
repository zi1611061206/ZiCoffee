using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface IService
    {
        bool AddService(Service service);

        DataTable GetAllService();

        Service GetServiceById(int serviceId);

        DataTable GetAllBillByStatus(ServiceStatus status);

        DataTable GetAllServiceOfCategory(int categoryId);

        bool UpdateService(Service service);

        bool DeleteAllService();

        bool DeleteServiceById(int serviceId);

        bool DeleteAllServiceByStatus(ServiceStatus status);

        bool DeleteAllServiceOfCategory(int categoryId);

        bool CheckServiceName(string serviceName);

        int CountAllService();

        DataTable SearchService(string serviceName);
    }
}
