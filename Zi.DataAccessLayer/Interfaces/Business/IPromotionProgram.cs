using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.Interfaces.Business
{
    public interface IPromotionProgram
    {
        bool AddPromotionProgram(PromotionProgram program);

        DataTable GetAllPromotionProgram();

        PromotionProgram GetPromotionProgramById(int programId);

        DataTable GetAllPromotionProgramByCreatedDate(DateTime start, DateTime end);

        DataTable GetAllPromotionProgramByStartTime(DateTime start, DateTime end);

        DataTable GetAllPromotionProgramByEndTime(DateTime start, DateTime end);

        DataTable GetAllPromotionProgramOfType(int typeId);

        bool UpdatePromotionProgram(PromotionProgram program);

        bool DeleteAllPromotionProgram();

        bool DeletePromotionProgramById(int programId);

        bool DeleteAllPromotionProgramOfType(int typeId);

        int CountAllPromotionProgram();

        DataTable SearchPromotionProgram(int programId);
    }
}
