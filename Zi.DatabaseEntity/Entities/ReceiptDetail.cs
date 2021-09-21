using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class ReceiptDetail
    {
        public Guid ReceiptId { get; set; }
        public Guid MaterialId { get; set; }
        public int Quantity { get; set; }
        public float ImportPrice { get; set; }

        //FK m-n
        public Receipt Receipt { get; set; }
        public Material Material { get; set; }
    }
}
