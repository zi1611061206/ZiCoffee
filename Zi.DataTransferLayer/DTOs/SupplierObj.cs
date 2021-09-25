using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs
{
    public class SupplierObj : Supplier
    {
        public SupplierObj()
        {
            SupplierId = Guid.NewGuid();
        }

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
