using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Seeders
{
    public class AreaSeeder
    {
        public AreaSeeder(ZiDbContext context)
        {
            IList<Area> areas = new List<Area>();

            #region // Floors
            areas.Add(new Area() { 
                AreaId = Guid.Parse(GuidConstants.AreaIdG),
                Name = "Ground Floor",
                ParentId = Guid.Empty
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1),
                Name = "1st Floor",
                ParentId = Guid.Empty
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId2),
                Name = "2nd Floor",
                ParentId = Guid.Empty
            });
            #endregion

            #region // Ground Floor
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaIdGA),
                Name = "G-A",
                ParentId = Guid.Parse(GuidConstants.AreaIdG)
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaIdGB),
                Name = "G-B",
                ParentId = Guid.Parse(GuidConstants.AreaIdG)
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaIdGC),
                Name = "G-C",
                ParentId = Guid.Parse(GuidConstants.AreaIdG)
            });
            #endregion

            #region // 1st Floor
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1A),
                Name = "1-A",
                ParentId = Guid.Parse(GuidConstants.AreaId1)
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1B),
                Name = "1-B",
                ParentId = Guid.Parse(GuidConstants.AreaId1)
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1C),
                Name = "1-C",
                ParentId = Guid.Parse(GuidConstants.AreaId1)
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId1D),
                Name = "1-D",
                ParentId = Guid.Parse(GuidConstants.AreaId1)
            });
            #endregion

            #region // 2nd Floor
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId2A),
                Name = "2-A",
                ParentId = Guid.Parse(GuidConstants.AreaId2)
            });
            areas.Add(new Area()
            {
                AreaId = Guid.Parse(GuidConstants.AreaId2B),
                Name = "2-B",
                ParentId = Guid.Parse(GuidConstants.AreaId2)
            });
            #endregion

            context.Areas.AddRange(areas);
            context.SaveChanges();
        }
    }
}
