﻿using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class BillDetailDTO
    {
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float IntoMoney { get; set; }

        public BillDetailDTO()
        {
        }

        public BillDetailDTO(Guid billId, Guid productId)
        {
            BillId = billId;
            ProductId = productId;
            Quantity = 1;
            IntoMoney = 0;
        }

        /// <summary>
        /// Mapping data to BillDetailObj
        /// </summary>
        /// <param name="row"></param>
        public BillDetailDTO(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Quantity = (int)row["Quantity"];
            IntoMoney = (float)row["IntoMoney"];
        }
    }
}
