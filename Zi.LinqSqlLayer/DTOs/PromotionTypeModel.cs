using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class PromotionTypeModel
    {
        public Guid PromotionTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PromotionTypeModel()
        {
        }

        public PromotionTypeModel(string name)
        {
            PromotionTypeId = Guid.NewGuid();
            Description = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to PromotiontypeObj
        /// </summary>
        /// <param name="row"></param>
        public PromotionTypeModel(DataRow row)
        {
            PromotionTypeId = Guid.Parse(row["PromotionTypeId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
