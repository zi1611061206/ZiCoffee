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
        private int promotionProgramId;
        private string content;
        private float value;
        private DateTime createdDate;
        private DateTime startDate;
        private DateTime endDate;
        private float minimumCondition;
        private int typeId;

        public int PromotionProgramId { get => promotionProgramId; set => promotionProgramId = value; }
        public string Content { get => content; set => content = value; }
        public float Value { get => value; set => this.value = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public float MinimumCondition { get => minimumCondition; set => minimumCondition = value; }
        public int TypeId { get => typeId; set => typeId = value; }

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
            DateTime result;
            if (DateTime.TryParse(row["NgayLap"].ToString(), out result))
                CreatedDate = result;
            DateTime result1;
            if (DateTime.TryParse(row["NgayBatDau"].ToString(), out result1))
                StartDate = result1;
            DateTime result2;
            if (DateTime.TryParse(row["NgayKetThuc"].ToString(), out result2))
                EndDate = result2;
            MinimumCondition = float.Parse(row["DieuKienToiThieu"].ToString());
            TypeId = (int)row["MaLoai"];
        }
    }
}
