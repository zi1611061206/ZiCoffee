using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class PromotionTypeService : IPromotionTypeService
    {
        #region Instance
        private static PromotionTypeService instance;
        public static PromotionTypeService Instance
        {
            get { if (instance == null) instance = new PromotionTypeService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private PromotionTypeService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(PromotionTypeModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var promotionType = new PromotionType()
                {
                    PromotionTypeId = model.PromotionTypeId,
                    Name = model.Name,
                    Description = model.Description
                };
                context.PromotionTypes.InsertOnSubmit(promotionType);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, promotionType.PromotionTypeId);
            }
        }

        public Tuple<bool, object> Delete(Guid promotionTypeId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var promotionType = context.PromotionTypes
                    .Where(x => x.PromotionTypeId.CompareTo(promotionTypeId) == 0)
                    .FirstOrDefault();
                if (promotionType == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + promotionTypeId);
                }
                context.PromotionTypes.DeleteOnSubmit(promotionType);

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

        public Tuple<bool, object> Read(PromotionTypeFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.PromotionTypes.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new PromotionTypeModel()
                {
                    PromotionTypeId = x.PromotionTypeId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<PromotionTypeModel>()
                {
                    TotalRecords = totalRecords,
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
        private IQueryable<PromotionType> GettingBy(IQueryable<PromotionType> query, PromotionTypeFilter filter)
        {
            if (filter.PromotionTypeId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.PromotionTypeId.CompareTo(filter.PromotionTypeId) == 0);
            }
            return query;
        }

        private IQueryable<PromotionType> Searching(IQueryable<PromotionType> query, PromotionTypeFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.PromotionTypeId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.PromotionTypeId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<PromotionType> Paging(IQueryable<PromotionType> query, PromotionTypeFilter filter)
        {
            if (filter.PageSize != 0)
            {
                int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
                query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            }
            return query;
        }

        private IQueryable<PromotionType> Sorting(IQueryable<PromotionType> query, PromotionTypeFilter filter)
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

        public Tuple<bool, object> Update(PromotionTypeModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var promotionType = context.PromotionTypes
                    .Where(x => x.PromotionTypeId.CompareTo(model.PromotionTypeId) == 0)
                    .FirstOrDefault();
                if (promotionType == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.PromotionTypeId);
                }
                promotionType.Name = model.Name;
                promotionType.Description = model.Description;

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
    }
}
