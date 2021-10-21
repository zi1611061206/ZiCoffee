using System;
using System.Collections.Generic;
using Zi.DatabaseEntity.Entities;
using Zi.Utilities.Constants;

namespace Zi.DatabaseEntity.Seeders
{
    public class AreaSeeder
    {
        public AreaSeeder(ZiDbContext context)
        {
            IList<Area> areas = new List<Area>();

            #region // Floors
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaIdG),
                Name = "Ground Floor",
                ParentId = string.Empty
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1),
                Name = "1st Floor",
                ParentId = string.Empty
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId2),
                Name = "2nd Floor",
                ParentId = string.Empty
            });
            #endregion

            #region // Ground Floor
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaIdGA),
                Name = "G-A",
                ParentId = GuidConstants.AreaIdG
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaIdGB),
                Name = "G-B",
                ParentId = GuidConstants.AreaIdG
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaIdGC),
                Name = "G-C",
                ParentId = GuidConstants.AreaIdG
            });
            #endregion

            #region // 1st Floor
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1A),
                Name = "1-A",
                ParentId = GuidConstants.AreaId1
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1B),
                Name = "1-B",
                ParentId = GuidConstants.AreaId1
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1C),
                Name = "1-C",
                ParentId = GuidConstants.AreaId1
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1D),
                Name = "1-D",
                ParentId = GuidConstants.AreaId1
            });
            #endregion

            #region // 2nd Floor
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId2A),
                Name = "2-A",
                ParentId = GuidConstants.AreaId2
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId2B),
                Name = "2-B",
                ParentId = GuidConstants.AreaId2
            });
            #endregion

            context.Areas.AddRange(areas);
            context.SaveChanges();
        }
    }
}
