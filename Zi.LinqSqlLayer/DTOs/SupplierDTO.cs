using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class SupplierDTO
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public SupplierDTO()
        {
        }

        public SupplierDTO(string name)
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
        public SupplierDTO(DataRow row)
        {
            SupplierId = Guid.Parse(row["SupplierId"].ToString());
            Name = row["Name"].ToString();
            Address = row["Address"].ToString();
            PhoneNumber = row["PhoneNumber"].ToString();
            Email = row["Email"].ToString();
        }
    }
}
