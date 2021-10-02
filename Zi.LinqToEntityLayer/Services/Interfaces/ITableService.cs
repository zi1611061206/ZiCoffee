using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Services.Interfaces
{
    public interface ITableService
    {
        Task<Paginator<Table>> GetTables(TableFilter filter);
        Task<bool> AddTable(Table table);
        Task<bool> UpdateTable(Table table);
        Task<bool> DeleteTable(Guid tableId);
    }
}
