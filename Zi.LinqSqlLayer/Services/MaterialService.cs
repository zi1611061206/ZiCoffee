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
    public class MaterialService : IMaterialService
    {
        public bool AddMaterial(MaterialDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var material = new Material()
                {
                    MaterialId = obj.MaterialId,
                    Name = obj.Name,
                    Unit = obj.Unit,
                    Quantity = obj.Quantity
                };
                context.Materials.InsertOnSubmit(material);
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

        public bool DeleteMaterial(Guid materialId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var material = context.Materials.Where(x => x.MaterialId.CompareTo(materialId) == 0).FirstOrDefault();
                context.Materials.DeleteOnSubmit(material);
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

        public Paginator<MaterialDTO> GetMaterials(MaterialFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Materials;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new MaterialDTO()
                {
                    MaterialId = x.MaterialId,
                    Name = x.Name,
                    Unit = x.Unit,
                    Quantity = x.Quantity
                });
                var result = new Paginator<MaterialDTO>()
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
        private Table<Material> GettingBy(Table<Material> query, MaterialFilter filter)
        {
            if (filter.MaterialId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.MaterialId.CompareTo(filter.MaterialId) == 0);
            }
            return query;
        }

        private Table<Material> Filtering(Table<Material> query, MaterialFilter filter)
        {
            query.Where(x => x.Quantity >= filter.QuantityMin);
            if (filter.QuantityMax > filter.QuantityMin)
            {
                query.Where(x => x.Quantity <= filter.QuantityMax);
            }
            return query;
        }

        private Table<Material> Searching(Table<Material> query, MaterialFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.MaterialId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Unit.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.MaterialId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Unit.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Material> Paging(Table<Material> query, MaterialFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Material> Sorting(Table<Material> query, MaterialFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.Unit);
            }
            else
            {
                query.OrderByDescending(x => x.Unit);
            }
            return query;
        }
        #endregion

        public bool UpdateMaterial(MaterialDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var material = context.Materials.Where(x => x.MaterialId.CompareTo(obj.MaterialId) == 0).FirstOrDefault();
                material.Name = obj.Name;
                material.Unit = obj.Unit;
                material.Quantity = obj.Quantity;
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
