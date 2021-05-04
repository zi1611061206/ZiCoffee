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
    public interface IProgramType
    {
        bool AddProgramType(ProgramType type);

        DataTable GetAllProgramType();

        ProgramType GetProgramTypeById(int typeId);
        
        bool UpdateProgramType(ProgramType type);

        bool DeleteAllProgramType();

        bool DeleteProgramTypeById(int typeId);

        int CountAllProgramType();

        DataTable SearchProgramType(string typeName);
    }
}
