using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Seeders
{
    public class TableSeeder
    {
        public TableSeeder(ZiDbContext context)
        {
            IList<Table> tables = new List<Table>();

            #region // G
            tables.Add(new Table() {
                TableId = Guid.Parse(GuidConstants.TableIdGA1),
                Name = "Bàn GA1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA2),
                Name = "Bàn GA2",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA3),
                Name = "Bàn GA3",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA4),
                Name = "Bàn GA4",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA5),
                Name = "Bàn GA5",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA6),
                Name = "Bàn GA6",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA7),
                Name = "Bàn GA7",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGB1),
                Name = "Bàn GB1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGB)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGC1),
                Name = "Bàn GC1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGC)
            });
            #endregion

            #region // 1
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A1),
                Name = "Bàn 1A1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A2),
                Name = "Bàn 1A2",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A3),
                Name = "Bàn 1A3",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A4),
                Name = "Bàn 1A4",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A5),
                Name = "Bàn 1A5",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A6),
                Name = "Bàn 1A6",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1B1),
                Name = "Bàn 1B1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1B)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1C1),
                Name = "Bàn 1C1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1C)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1D1),
                Name = "Bàn 1D1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1D)
            });
            #endregion

            #region // 2
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId2A1),
                Name = "Bàn 2A1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId2A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId2B1),
                Name = "Bàn 2B1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId2B)
            });
            #endregion

            context.Tables.AddRange(tables);
            context.SaveChanges();
        }
    }
}
