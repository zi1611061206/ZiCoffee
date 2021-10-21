using System;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class UserFilter : PaginatorConfiguration
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirthFrom { get; set; }
        public DateTime DateOfBirthTo { get; set; }
        public DateTime CreatedDateFrom { get; set; }
        public DateTime CreatedDateTo { get; set; }
        public Genders? Gender { get; set; }

        public UserFilter()
        {
            UserId = Guid.Empty;
            Username = string.Empty;
            DateOfBirthFrom = DateTime.MinValue;
            DateOfBirthTo = DateTime.MaxValue;
            CreatedDateFrom = DateTime.MinValue;
            CreatedDateTo = DateTime.MaxValue;
            Gender = null;
        }
    }
}
