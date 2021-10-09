using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface ISupplierService
    {
        /// <summary>
        /// This method retrieves suppliers from the supplier table.
        /// <para>PARAMETERS</para>
        /// <para>- The filter parameter is used to support keyword searching, filtering by unique attributes or domain attributes of the table, pagination, and sorting.</para>
        /// <para>- The cultureName parameter defines the return language of the error message.</para>
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = Paginator<SupplierModel>(a list containing at least one SupplierModel object).</para>
        /// <para>+ Item1 = false => Item2 = "Message String".</para>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Read(SupplierFilter filter, string cultureName);

        /// <summary>
        /// This method saves a new supplier to the supplier table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = SupplierId (là Guid của supplier vừa được lưu).</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Create(SupplierModel model, string cultureName);

        /// <summary>
        /// This method updates the data of a supplier that exists in the supplier table.
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
        Tuple<bool, object> Update(SupplierModel model, string cultureName);

        /// <summary>
        /// This method remove a supplier that exists in the supplier table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any. </para>
        /// <para>+ Item1 = true => Item2 = null.</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Delete(Guid supplierId, string cultureName);
    }
}
