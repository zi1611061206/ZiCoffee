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
        private int billId;
        private DateTime createdDate;
        private BillStatus payStatus;
        private float realPay;
        private float vat;
        private int discountNoteId;
        private int promotionProgramId;
        private float total;
        private float afterVAT;

        public int BillId { get => billId; set => billId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public BillStatus PayStatus { get => payStatus; set => payStatus = value; }
        public float RealPay { get => realPay; set => realPay = value; }
        public float Vat { get => vat; set => vat = value; }
        public int DiscountNoteId { get => discountNoteId; set => discountNoteId = value; }
        public int PromotionProgramId { get => promotionProgramId; set => promotionProgramId = value; }
        public float Total { get => total; set => total = value; }
        public float AfterVAT { get => afterVAT; set => afterVAT = value; }

        public Bill()
        {

        }

        public Bill(int billId, DateTime createdDate, BillStatus payStatus, float realPay, float vat, int discountNoteId, int promotionProgramId, float total, float afterVAT)
        {
            this.BillId = billId;
            this.CreatedDate = createdDate;
            this.PayStatus = payStatus;
            this.RealPay = realPay;
            this.Vat = vat;
            this.DiscountNoteId = discountNoteId;
            this.PromotionProgramId = promotionProgramId;
            this.Total = total;
            this.AfterVAT = afterVAT;
        }

        public Bill(DataRow row)
        {
            this.BillId = (int)row["MaHoaDon"];
            DateTime result;
            if (DateTime.TryParse(row["NgayLap"].ToString(), out result))
                this.CreatedDate = result;
            int status = Convert.ToInt32(row["TrangThaiThanhToan"]);
            this.PayStatus = (BillStatus) status;
            this.RealPay = float.Parse(row["ThucThu"].ToString());
            this.Vat = float.Parse(row["Vat"].ToString());

            string noteId = row["MaPhieuGiamGia"].ToString();
            if (!String.IsNullOrEmpty(noteId))
            {
                this.DiscountNoteId = (int)row["MaPhieuGiamGia"];
            }

            string programId = row["MaChuongTrinhKhuyenMai"].ToString();
            if (!String.IsNullOrEmpty(programId))
            {
                this.PromotionProgramId = (int)row["MaChuongTrinhKhuyenMai"];
            }

            this.Total = float.Parse(row["ThanhTien"].ToString());
            this.AfterVAT = float.Parse(row["GiaTriSauThue"].ToString());
        }
    }
}
