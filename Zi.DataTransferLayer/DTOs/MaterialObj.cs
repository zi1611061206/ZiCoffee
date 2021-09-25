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
        public MaterialObj()
        {
            MaterialId = Guid.NewGuid();
        }

        public MaterialObj(DataRow row)
        {
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Name = row["Name"].ToString();
            Unit = row["Unit"].ToString();
            Quantity = (int)row["Quantity"];
        }
    }
}
