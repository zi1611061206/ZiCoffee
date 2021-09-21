using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class Receipt
    {
        public Guid ReceiptId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid SupplierId { get; set; }

        //FK n-1
        public Supplier Supplier { get; set; }

        //FK 1-n (m-n)
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
