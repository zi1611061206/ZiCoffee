using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class PromotionTypeService : IPromotionTypeService
    {
        public bool AddPromotionType(PromotionTypeDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var promotionType = new PromotionType()
                {
                    PromotionTypeId = obj.PromotionTypeId,
                    Name = obj.Name,
                    Description = obj.Description
                };
                context.PromotionTypes.InsertOnSubmit(promotionType);
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

        public bool DeletePromotionType(Guid promotionTypeId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var promotionType = context.PromotionTypes.Where(x => x.PromotionTypeId.CompareTo(promotionTypeId) == 0).FirstOrDefault();
                context.PromotionTypes.DeleteOnSubmit(promotionType);
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

        public Paginator<PromotionTypeDTO> GetAreaPromotionTypes(PromotionTypeFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.PromotionTypes;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new PromotionTypeDTO()
                {
                    PromotionTypeId = x.PromotionTypeId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<PromotionTypeDTO>()
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
        private Table<PromotionType> GettingBy(Table<PromotionType> query, PromotionTypeFilter filter)
        {
            if (filter.PromotionTypeId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.PromotionTypeId.CompareTo(filter.PromotionTypeId) == 0);
            }
            return query;
        }

        private Table<PromotionType> Searching(Table<PromotionType> query, PromotionTypeFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.PromotionTypeId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.PromotionTypeId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<PromotionType> Paging(Table<PromotionType> query, PromotionTypeFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<PromotionType> Sorting(Table<PromotionType> query, PromotionTypeFilter filter)
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

        public bool UpdatePromotionType(PromotionTypeDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var promotionType = context.PromotionTypes.Where(x => x.PromotionTypeId.CompareTo(obj.PromotionTypeId) == 0).FirstOrDefault();
                promotionType.Name = obj.Name;
                promotionType.Description = obj.Description;
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
