using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataTransferLayer.DTOs
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime CreatedDate { get; set; }
        public BillStatus PayStatus { get; set; }
        public float RealPay { get; set; }
        public float Vat { get; set; }
        public int DiscountNoteId { get; set; }
        public int PromotionProgramId { get; set; }
        public float Total { get; set; }
        public float AfterVAT { get; set; }

        public Bill()
        {

        }

        public Bill(int billId, DateTime createdDate, BillStatus payStatus, float realPay, float vat, int discountNoteId, int promotionProgramId, float total, float afterVAT)
        {
            BillId = billId;
            CreatedDate = createdDate;
            PayStatus = payStatus;
            RealPay = realPay;
            Vat = vat;
            DiscountNoteId = discountNoteId;
            PromotionProgramId = promotionProgramId;
            Total = total;
            AfterVAT = afterVAT;
        }

        public Bill(DataRow row)
        {
            BillId = (int)row["MaHoaDon"];
            if (DateTime.TryParse(row["NgayLap"].ToString(), out DateTime result))
            {
                CreatedDate = result;
            }
            int status = Convert.ToInt32(row["TrangThaiThanhToan"]);
            PayStatus = (BillStatus) status;
            RealPay = float.Parse(row["ThucThu"].ToString());
            Vat = float.Parse(row["Vat"].ToString());

            string noteId = row["MaPhieuGiamGia"].ToString();
            if (!string.IsNullOrEmpty(noteId))
            {
                DiscountNoteId = (int)row["MaPhieuGiamGia"];
            }

            string programId = row["MaChuongTrinhKhuyenMai"].ToString();
            if (!string.IsNullOrEmpty(programId))
            {
                PromotionProgramId = (int)row["MaChuongTrinhKhuyenMai"];
            }

            Total = float.Parse(row["ThanhTien"].ToString());
            AfterVAT = float.Parse(row["GiaTriSauThue"].ToString());
        }
    }
}
