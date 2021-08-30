using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class ProgramType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public ProgramType(int typeId, string typeName)
        {
            TypeId = typeId;
            TypeName = typeName;
        }

        public ProgramType(DataRow row)
        {
            TypeId = (int)row["MaLoai"];
            TypeName = row["TenLoai"].ToString();
        }
    }
}
