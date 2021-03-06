using System;
using System.Collections.Generic;
using Zi.DatabaseEntity.Entities;
using Zi.Utilities.Constants;
using Zi.Utilities.Enumerators;

namespace Zi.DatabaseEntity.Seeders
{
    public class TableSeeder
    {
        public TableSeeder(ZiDbContext context)
        {
            IList<Table> tables = new List<Table>();

            #region // G
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA1),
                Name = "GA1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA2),
                Name = "GA2",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA3),
                Name = "GA3",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA4),
                Name = "GA4",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA5),
                Name = "GA5",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA6),
                Name = "GA6",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGA7),
                Name = "GA7",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGA)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGB1),
                Name = "GB1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGB)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableIdGC1),
                Name = "GC1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaIdGC)
            });
            #endregion

            #region // 1
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A1),
                Name = "1A1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A2),
                Name = "1A2",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A3),
                Name = "1A3",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A4),
                Name = "1A4",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A5),
                Name = "1A5",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1A6),
                Name = "1A6",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1B1),
                Name = "1B1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1B)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1C1),
                Name = "1C1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1C)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId1D1),
                Name = "1D1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId1D)
            });
            #endregion

            #region // 2
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId2A1),
                Name = "2A1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId2A)
            });
            tables.Add(new Table()
            {
                TableId = Guid.Parse(GuidConstants.TableId2B1),
                Name = "2B1",
                Status = TableStatus.Ready,
                AreaId = Guid.Parse(GuidConstants.AreaId2B)
            });
            #endregion

            context.Tables.AddRange(tables);
            context.SaveChanges();
        }
    }
}
