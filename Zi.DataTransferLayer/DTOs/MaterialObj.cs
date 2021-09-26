using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs
{
    public class MaterialObj : Material
    {
        public MaterialObj(string name, string unit)
        {
            MaterialId = Guid.NewGuid();
            Quantity = 1;
            Name = name;
            Unit = unit;
        }

        /// <summary>
        /// Mapping data to MaterialObj
        /// </summary>
        /// <param name="row"></param>
        public MaterialObj(DataRow row)
        {
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Name = row["Name"].ToString();
            Unit = row["Unit"].ToString();
            Quantity = (int)row["Quantity"];
        }
    }
}
