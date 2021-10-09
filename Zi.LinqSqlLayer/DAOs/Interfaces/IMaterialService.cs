using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IMaterialService
    {
        /// <summary>
        /// This method retrieves materials from the material table.
        /// <para>PARAMETERS</para>
        /// <para>- The filter parameter is used to support keyword searching, filtering by unique attributes or domain attributes of the table, pagination, and sorting.</para>
        /// <para>- The cultureName parameter defines the return language of the error message.</para>
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = Paginator<MaterialModel>(a list containing at least one MaterialModel object).</para>
        /// <para>+ Item1 = false => Item2 = "Message String".</para>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Read(MaterialFilter filter, string cultureName);

        /// <summary>
        /// This method saves a new material to the material table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any.</para>
        /// <para>+ Item1 = true => Item2 = MaterialId (là Guid của material vừa được lưu).</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Create(MaterialModel model, string cultureName);

        /// <summary>
        /// This method updates the data of a material that exists in the material table.
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
        Tuple<bool, object> Update(MaterialModel model, string cultureName);

        /// <summary>
        /// This method remove a material that exists in the material table.
        /// <para>RETURNS</para>
        /// <para>The method returns a tuple of 2 items:</para>
        /// <para>- Item1 (bool) indicates the data query execution result.</para>
        /// <para>- Item2 (object) contains the return data if any. </para>
        /// <para>+ Item1 = true => Item2 = null.</para>
        /// <para>+ Item1 = false => Item2 = "Error message string".</para>
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        Tuple<bool, object> Delete(Guid materialId, string cultureName);
    }
}
