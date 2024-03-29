﻿using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class MaterialModel
    {
        public Guid MaterialId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }

        public MaterialModel()
        {
        }

        public MaterialModel(string name, string unit)
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
        public MaterialModel(DataRow row)
        {
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Name = row["Name"].ToString();
            Unit = row["Unit"].ToString();
            Quantity = (int)row["Quantity"];
        }
    }
}
