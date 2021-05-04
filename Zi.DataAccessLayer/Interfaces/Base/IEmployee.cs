using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface IEmployee
    {
        bool AddEmployee(Employee employee);

        DataTable GetAllEmployee();

        Employee GetEmployeeById(int employeeId);

        DataTable GetAllEmployeeOfPosition(int positionId);

        bool UpdateEmployee(Employee employee);

        bool DeleteAllEmployee();

        bool DeleteEmployeeById(int employeeId);

        bool DeleteAllEmployeeOfPosition(int positionId);

        bool CheckCitizenId(string citizenId);

        int CountAllEmployee();

        DataTable SearchEmployee(string fName, string mName, string lName);
    }
}
