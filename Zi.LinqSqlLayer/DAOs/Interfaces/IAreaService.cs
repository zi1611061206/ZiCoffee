using System;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IAreaService
    {
        /// <summary>
        /// This method retrieves areas from the area table.
        /// <para>PARAMETERS</para>
        /// <para>- The filter parameter is used to support keyword searching, filtering by unique attributes or domain attributes of the table, pagination, and sorting.</para>
        /// <para>- The cultureName parameter defines the return language of the error message.</para>
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = Paginator<AreaModel>(a list containing at least one AreaModel object).</para>
        /// <para>+ Item1 = false => Item2 = "Message String".</para>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Read(AreaFilter filter, string cultureName);

        /// <summary>
        /// This method saves a new area to the area table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = AreaId (là Guid của area vừa được lưu).</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Create(AreaModel model, string cultureName);

        /// <summary>
        /// This method updates the data of a area that exists in the area table.
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
        Tuple<bool, object> Update(AreaModel model, string cultureName);

        /// <summary>
        /// This method remove a area that exists in the area table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any. </para>
        /// <para>+ Item1 = true => Item2 = null.</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Delete(Guid areaId, string cultureName);
    }
}
