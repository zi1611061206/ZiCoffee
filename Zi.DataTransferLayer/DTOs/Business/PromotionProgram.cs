using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class PromotionProgram
    {
        public int PromotionProgramId { get; set; }
        public string Content { get; set; }
        public float Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float MinimumCondition { get; set; }
        public int TypeId { get; set; }

        public PromotionProgram(int promotionProgramId, string content, float value, DateTime createdDate, DateTime startDate, DateTime endDate, float minimumCondition, int typeId)
        {
            PromotionProgramId = promotionProgramId;
            Content = content;
            Value = value;
            CreatedDate = createdDate;
            StartDate = startDate;
            EndDate = endDate;
            MinimumCondition = minimumCondition;
            TypeId = typeId;
        }

        public PromotionProgram(DataRow row)
        {
            PromotionProgramId = (int)row["MaChuongTrinh"];
            Content = row["NoiDung"].ToString();
            Value = float.Parse(row["GiaTri"].ToString());
            if (DateTime.TryParse(row["NgayLap"].ToString(), out DateTime result))
            {
                CreatedDate = result;
            }
            if (DateTime.TryParse(row["NgayBatDau"].ToString(), out DateTime result1))
            {
                StartDate = result1;
            }
            if (DateTime.TryParse(row["NgayKetThuc"].ToString(), out DateTime result2))
            {
                EndDate = result2;
            }
            MinimumCondition = float.Parse(row["DieuKienToiThieu"].ToString());
            TypeId = (int)row["MaLoai"];
        }
    }
}
