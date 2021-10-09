using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// This method retrieves products from the product table.
        /// <para>PARAMETERS</para>
        /// <para>- The filter parameter is used to support keyword searching, filtering by unique attributes or domain attributes of the table, pagination, and sorting.</para>
        /// <para>- The cultureName parameter defines the return language of the error message.</para>
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = Paginator<ProductModel>(a list containing at least one ProductModel object).</para>
        /// <para>+ Item1 = false => Item2 = "Message String".</para>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Read(ProductFilter filter, string cultureName);

        /// <summary>
        /// This method saves a new product to the product table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = ProductId (là Guid của product vừa được lưu).</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Create(ProductModel model, string cultureName);

        /// <summary>
        /// This method updates the data of a product that exists in the product table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = null.</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Update(ProductModel model, string cultureName);

        /// <summary>
        /// This method remove a product that exists in the product table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any. </para>
        /// <para>+ Item1 = true => Item2 = null.</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Delete(Guid productId, string cultureName);
    }
}
