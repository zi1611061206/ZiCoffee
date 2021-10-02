using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs
{
    public class SupplierObj : Supplier
    {
        public SupplierObj(string name)
        {
            SupplierId = Guid.NewGuid();
            Address = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to SupplierObj
        /// </summary>
        /// <param name="row"></param>
        public SupplierObj(DataRow row)
        {
            SupplierId = Guid.Parse(row["SupplierId"].ToString());
            Name = row["Name"].ToString();
            Address = row["Address"].ToString();
            PhoneNumber = row["PhoneNumber"].ToString();
            Email = row["Email"].ToString();
        }
    }
}
