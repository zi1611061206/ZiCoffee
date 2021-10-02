using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;
using Zi.LinqToEntityLayer.Services.Interfaces;

namespace Zi.LinqToEntityLayer.Services
{
    public class TableService : ITableService
    {
        public async Task<bool> AddTable(Table table)
        {
            using (var context = new ZiDbContext())
            {
                context.Tables.Add(table);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteTable(Guid tableId)
        {
            using (var context = new ZiDbContext())
            {
                var table = await context.Tables.FindAsync(tableId);
                context.Tables.Remove(table);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Table>> GetTables(TableFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Tables;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Table()
                {
                    TableId = x.TableId,
                    Name = x.Name,
                    Status = x.Status,
                    AreaId = x.AreaId
                });
                var result = new Paginator<Table>()
                {
                    TotalRecords = await data.CountAsync(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = await data.ToListAsync()
                };
                return result;
            }
        }

        #region Engines
        private DbSet<Table> GettingBy(DbSet<Table> query, TableFilter filter)
        {
            if (filter.TableId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.TableId.CompareTo(filter.TableId) == 0);
            }
            return query;
        }

        private DbSet<Table> Filtering(DbSet<Table> query, TableFilter filter)
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

        private DbSet<Table> Searching(DbSet<Table> query, TableFilter filter)
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

        private DbSet<Table> Paging(DbSet<Table> query, TableFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Table> Sorting(DbSet<Table> query, TableFilter filter)
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

        public async Task<bool> UpdateTable(Table table)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Tables.FindAsync(table.TableId);
                data.Name = table.Name;
                data.Status = table.Status;
                data.AreaId = table.AreaId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
