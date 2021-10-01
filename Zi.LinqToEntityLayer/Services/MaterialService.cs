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
    public class MaterialService : IMaterialService
    {
        public async Task<bool> AddMaterial(Material material)
        {
            using (var context = new ZiDbContext())
            {
                context.Materials.Add(material);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteMaterial(Guid materialId)
        {
            using (var context = new ZiDbContext())
            {
                var material = await context.Materials.FindAsync(materialId);
                context.Materials.Remove(material);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<Material> GetMaterials(MaterialFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Materials;
                query = GettingBy(query, filter);
                query = Filtering(query, filter);
                query = Searching(query, filter);
                query = Paging(query, filter);
                query = Sorting(query, filter);
                // Mapping data
                var data = query.Select(x => new Material()
                {
                    MaterialId = x.MaterialId,
                    Name = x.Name,
                    Unit = x.Unit,
                    Quantity = x.Quantity
                });
                var result = new Paginator<Material>()
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
        private DbSet<Material> GettingBy(DbSet<Material> query, MaterialFilter filter)
        {
            if (filter.MaterialId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.MaterialId.CompareTo(filter.MaterialId) == 0);
            }
            return query;
        }

        private DbSet<Material> Filtering(DbSet<Material> query, MaterialFilter filter)
        {
            query.Where(x => x.Quantity >= filter.QuantityMin);
            if (filter.QuantityMax > filter.QuantityMin)
            {
                query.Where(x => x.Quantity <= filter.QuantityMax);
            }
            return query;
        }

        private DbSet<Material> Searching(DbSet<Material> query, MaterialFilter filter)
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

        private DbSet<Material> Paging(DbSet<Material> query, MaterialFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Material> Sorting(DbSet<Material> query, MaterialFilter filter)
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

        public async Task<bool> UpdateMaterial(Material material)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Materials.FindAsync(material.MaterialId);
                data.Name = material.Name;
                data.Unit = material.Unit;
                data.Quantity = material.Quantity;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
