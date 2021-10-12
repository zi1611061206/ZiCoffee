using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class TableService : ITableService
    {
        #region Instance
        private static TableService instance;
        public static TableService Instance
        {
            get { if (instance == null) instance = new TableService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private TableService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(TableModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var table = new Table()
                {
                    TableId = model.TableId,
                    Name = model.Name,
                    Status = (int)model.Status,
                    AreaId = model.AreaId
                };
                context.Tables.InsertOnSubmit(table);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, table.TableId);
            }
        }

        public Tuple<bool, object> Delete(Guid tableId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var table = context.Tables
                    .Where(x => x.TableId.CompareTo(tableId) == 0)
                    .FirstOrDefault();
                if (table == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + tableId);
                }
                context.Tables.DeleteOnSubmit(table);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedDelete", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Read(TableFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Tables.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new TableModel()
                {
                    TableId = x.TableId,
                    Name = x.Name,
                    Status = (TableStatus)x.Status,
                    AreaId = x.AreaId
                });
                var result = new Paginator<TableModel>()
                {
                    TotalRecords = data.Count(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                if (data.Count() <= 0)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                return new Tuple<bool, object>(true, result);
            }
        }

        #region Engines
        private IQueryable<Table> GettingBy(IQueryable<Table> query, TableFilter filter)
        {
            if (filter.TableId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.TableId.CompareTo(filter.TableId) == 0);
            }
            return query;
        }

        private IQueryable<Table> Filtering(IQueryable<Table> query, TableFilter filter)
        {
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            if (filter.AreaId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.AreaId.CompareTo(filter.AreaId) == 0);
            }
            return query;
        }

        private IQueryable<Table> Searching(IQueryable<Table> query, TableFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.TableId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.AreaId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.TableId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.AreaId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Table> Paging(IQueryable<Table> query, TableFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Table> Sorting(IQueryable<Table> query, TableFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.Name);
            }
            else
            {
                query = query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(TableModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var table = context.Tables
                    .Where(x => x.TableId.CompareTo(model.TableId) == 0)
                    .FirstOrDefault();
                if (table == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.TableId);
                }
                table.Name = model.Name;
                table.Status = (int)model.Status;
                table.AreaId = model.AreaId;

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedUpdate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<int, int, int, int> CountTable()
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Tables;
                var totalTable = query.Count();
                var readyTable = query.Where(x => x.Status.Equals(TableStatus.Ready)).Count();
                var usingTable = query.Where(x => x.Status.Equals(TableStatus.Using)).Count();
                var pendingTable = query.Where(x => x.Status.Equals(TableStatus.Pending)).Count();
                return new Tuple<int, int, int, int>(totalTable, readyTable, usingTable, pendingTable);
            }
        }
    }
}
