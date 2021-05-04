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
    public interface ITable
    {
        bool AddTable(Table table);

        DataTable GetAllTable();

        Table GetTableById(int tableId);

        DataTable GetAllTableByStatus(TableStatus status);

        DataTable GetAllTableOfArea(int areaId);

        bool UpdateTable(Table table);

        bool DeleteAllTable();

        bool DeleteTableById(int tableId);

        bool DeleteAllTableByStatus(TableStatus status);

        bool DeleteAllTableOfArea(int areaId);

        bool CheckTableAndArea(int areaId, string tableName);

        int CountAllTable();

        int CountAllTableByStatus(TableStatus status);

        DataTable SearchTable(string tableName);
    }
}
