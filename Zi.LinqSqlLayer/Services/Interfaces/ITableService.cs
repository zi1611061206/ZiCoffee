using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface ITableService
    {
        Paginator<TableDTO> GetTables(TableFilter filter);
        bool AddTable(TableDTO obj);
        bool UpdateTable(TableDTO obj);
        bool DeleteTable(Guid tableId);
    }
}
