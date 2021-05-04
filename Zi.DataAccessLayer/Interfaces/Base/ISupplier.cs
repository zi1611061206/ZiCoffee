using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface ISupplier
    {
        bool AddSupplier(Supplier supplier);

        DataTable GetAllSupplier();

        Supplier GetSupplierById(int sụpplierId);

        bool UpdateSupplier(Supplier supplier);

        bool DeleteAllSupplier();

        bool DeleteSupplierById(int supplierId);

        bool CheckSupplierName(string supplierName);

        int CountAllSupplier();

        DataTable SearchSupplier(string supplierName);
    }
}
