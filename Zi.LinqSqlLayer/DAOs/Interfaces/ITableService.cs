using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface ITableService
    {
        /// <summary>
        /// This method retrieves tables from the table table.
        /// <para>PARAMETERS</para>
        /// <para>- The filter parameter is used to support keyword searching, filtering by unique attributes or domain attributes of the table, pagination, and sorting.</para>
        /// <para>- The cultureName parameter defines the return language of the error message.</para>
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = Paginator<TableModel>(a list containing at least one TableModel object).</para>
        /// <para>+ Item1 = false => Item2 = "Message String".</para>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Read(TableFilter filter, string cultureName);

        /// <summary>
        /// This method saves a new table to the table table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = TableId (là Guid của table vừa được lưu).</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Create(TableModel model, string cultureName);

        /// <summary>
        /// This method updates the data of a table that exists in the table table.
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
        Tuple<bool, object> Update(TableModel model, string cultureName);

        /// <summary>
        /// This method remove a table that exists in the table table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any. </para>
        /// <para>+ Item1 = true => Item2 = null.</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Delete(Guid tableId, string cultureName);

        /// <summary>
        /// This method count table by each status.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 4 items:</para>
        /// <para>- Item1 (int) total table.</para>
        /// <para>- Item2 (int) ready table.</para>
        /// <para>- Item3 (int) using table.</para>
        /// <para>- Item4 (int) pending table.</para>
        /// </summary>
        /// <returns></returns>
        Tuple<int, int, int, int> CountTable();

        /// <summary>
        /// This method count all tables.
        /// <para>RETURNS</para>
        /// <para>- TableTotal (int).</para>
        /// </summary>
        /// <returns></returns>
        int CountAll();

        /// <summary>
        /// This method count all tables of an area.
        /// <para>RETURNS</para>
        /// <para>- Amount of table in area (int).</para>
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        int CountByArea(Guid areaId);
    }
}
