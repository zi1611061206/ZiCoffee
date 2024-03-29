﻿using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class ReceiptDetailService : IReceiptDetailService
    {
        #region Instance
        private static ReceiptDetailService instance;
        public static ReceiptDetailService Instance
        {
            get { if (instance == null) instance = new ReceiptDetailService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private ReceiptDetailService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(ReceiptDetailModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var receiptDetail = new ReceiptDetail()
                {
                    ReceiptId = model.ReceiptId,
                    MaterialId = model.MaterialId,
                    Quantity = model.Quantity,
                    ImportPrice = model.ImportPrice
                };
                context.ReceiptDetails.InsertOnSubmit(receiptDetail);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Delete(Guid receiptId, Guid materialId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var receiptDetail = context.ReceiptDetails
                    .Where(x => x.ReceiptId.CompareTo(receiptId) == 0 && x.MaterialId.CompareTo(materialId) == 0)
                    .FirstOrDefault();
                if (receiptDetail == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                context.ReceiptDetails.DeleteOnSubmit(receiptDetail);

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

        public Tuple<bool, object> Read(ReceiptDetailFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.ReceiptDetails.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new ReceiptDetailModel()
                {
                    ReceiptId = x.ReceiptId,
                    MaterialId = x.MaterialId,
                    Quantity = x.Quantity,
                    ImportPrice = x.ImportPrice
                });
                var result = new Paginator<ReceiptDetailModel>()
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
        private IQueryable<ReceiptDetail> GettingBy(IQueryable<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            if (filter.ReceiptId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.ReceiptId.CompareTo(filter.ReceiptId) == 0);
            }
            if (filter.MaterialId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.MaterialId.CompareTo(filter.MaterialId) == 0);
            }
            return query;
        }

        private IQueryable<ReceiptDetail> Filtering(IQueryable<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            query = query.Where(x => x.Quantity >= filter.QuantityMin);
            if (filter.QuantityMax > filter.QuantityMin)
            {
                query = query.Where(x => x.Quantity <= filter.QuantityMax);
            }
            query = query.Where(x => x.ImportPrice >= filter.ImportPriceMin);
            if (filter.ImportPriceMax > filter.ImportPriceMin)
            {
                query = query.Where(x => x.ImportPrice <= filter.ImportPriceMax);
            }
            return query;
        }

        private IQueryable<ReceiptDetail> Searching(IQueryable<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.ReceiptId.ToString().Contains(filter.Keyword) ||
                        x.MaterialId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.ReceiptId.ToString().Equals(filter.Keyword) ||
                        x.MaterialId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<ReceiptDetail> Paging(IQueryable<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            if (filter.PageSize != 0)
            {
                int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
                query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            }
            return query;
        }

        private IQueryable<ReceiptDetail> Sorting(IQueryable<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.ReceiptId);
            }
            else
            {
                query = query.OrderByDescending(x => x.ReceiptId);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(ReceiptDetailModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var receiptDetail = context.ReceiptDetails
                    .Where(x => x.ReceiptId.CompareTo(model.ReceiptId) == 0 && x.MaterialId.CompareTo(model.MaterialId) == 0)
                    .FirstOrDefault();
                if (receiptDetail == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                receiptDetail.Quantity = model.Quantity;
                receiptDetail.ImportPrice = model.ImportPrice;

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
