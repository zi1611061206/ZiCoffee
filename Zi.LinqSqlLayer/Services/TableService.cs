using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class TableService : ITableService
    {
        public bool AddTable(TableDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var table = new Table()
                {
                    TableId = obj.TableId,
                    Name = obj.Name,
                    Status = (int)obj.Status,
                    AreaId = obj.AreaId
                };
                context.Tables.InsertOnSubmit(table);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteTable(Guid tableId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var table = context.Tables.Where(x => x.TableId.CompareTo(tableId) == 0).FirstOrDefault();
                context.Tables.DeleteOnSubmit(table);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<TableDTO> GetTables(TableFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Tables;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new TableDTO()
                {
                    TableId = x.TableId,
                    Name = x.Name,
                    Status = (TableStatus)x.Status,
                    AreaId = x.AreaId
                });
                var result = new Paginator<TableDTO>()
                {
                    TotalRecords = data.Count(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                return result;
            }
        }

        #region Engines
        private Table<Table> GettingBy(Table<Table> query, TableFilter filter)
        {
            if (filter.TableId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.TableId.CompareTo(filter.TableId) == 0);
            }
            return query;
        }

        private Table<Table> Filtering(Table<Table> query, TableFilter filter)
        {
            if (filter.Status.HasValue)
            {
                query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            if (filter.AreaId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.AreaId.CompareTo(filter.AreaId) == 0);
            }
            return query;
        }

        private Table<Table> Searching(Table<Table> query, TableFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.TableId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.AreaId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.TableId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.AreaId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Table> Paging(Table<Table> query, TableFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Table> Sorting(Table<Table> query, TableFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.Name);
            }
            else
            {
                query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public bool UpdateTable(TableDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var table = context.Tables.Where(x => x.TableId.CompareTo(obj.TableId) == 0).FirstOrDefault();
                table.Name = obj.Name;
                table.Status = (int)obj.Status;
                table.AreaId = obj.AreaId;
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
    }
}
