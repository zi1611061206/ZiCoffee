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
    public class MaterialService : IMaterialService
    {
        #region Instance
        private static MaterialService instance;
        public static MaterialService Instance
        {
            get { if (instance == null) instance = new MaterialService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private MaterialService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(MaterialModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var material = new Material()
                {
                    MaterialId = model.MaterialId,
                    Name = model.Name,
                    Unit = model.Unit,
                    Quantity = model.Quantity
                };
                context.Materials.InsertOnSubmit(material);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, material.MaterialId);
            }
        }

        public Tuple<bool, object> Delete(Guid materialId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var material = context.Materials
                    .Where(x => x.MaterialId.CompareTo(materialId) == 0)
                    .FirstOrDefault();
                if (material == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + materialId);
                }
                context.Materials.DeleteOnSubmit(material);

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

        public Tuple<bool, object> Read(MaterialFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Materials.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new MaterialModel()
                {
                    MaterialId = x.MaterialId,
                    Name = x.Name,
                    Unit = x.Unit,
                    Quantity = x.Quantity
                });
                var result = new Paginator<MaterialModel>()
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
        private IQueryable<Material> GettingBy(IQueryable<Material> query, MaterialFilter filter)
        {
            if (filter.MaterialId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.MaterialId.CompareTo(filter.MaterialId) == 0);
            }
            return query;
        }

        private IQueryable<Material> Filtering(IQueryable<Material> query, MaterialFilter filter)
        {
            query = query.Where(x => x.Quantity >= filter.QuantityMin);
            if (filter.QuantityMax > filter.QuantityMin)
            {
                query = query.Where(x => x.Quantity <= filter.QuantityMax);
            }
            return query;
        }

        private IQueryable<Material> Searching(IQueryable<Material> query, MaterialFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.MaterialId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Unit.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.MaterialId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Unit.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Material> Paging(IQueryable<Material> query, MaterialFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Material> Sorting(IQueryable<Material> query, MaterialFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.Unit);
            }
            else
            {
                query = query.OrderByDescending(x => x.Unit);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(MaterialModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var material = context.Materials
                    .Where(x => x.MaterialId.CompareTo(model.MaterialId) == 0)
                    .FirstOrDefault();
                if (material == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.MaterialId);
                }
                material.Name = model.Name;
                material.Unit = model.Unit;
                material.Quantity = model.Quantity;

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
