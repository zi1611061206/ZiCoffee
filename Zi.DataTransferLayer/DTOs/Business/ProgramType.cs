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
        private int typeId;
        private string typeName;

        public int TypeId { get => typeId; set => typeId = value; }
        public string TypeName { get => typeName; set => typeName = value; }

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
