using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Convertors;
using Zi.LinqToEntityLayer.Engines.Encoders;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;
using Zi.LinqToEntityLayer.Services.Interfaces;

namespace Zi.LinqToEntityLayer.Services
{
    public class UserService : IUserService
    {
        public async Task<bool> AddUser(User user)
        {
            using (var context = new ZiDbContext())
            {
                context.Users.Add(user);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            using (var context = new ZiDbContext())
            {
                var user = await context.Users.FindAsync(userId);
                context.Users.Remove(user);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<User>> GetUsers(UserFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Users;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Use to mapping data
                var data = query.Select(x => new User()
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Username = x.Username,
                    DisplayName = x.DisplayName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    DateOfBirth = x.DateOfBirth,
                    CreatedDate = x.CreatedDate,
                    Gender = x.Gender,
                    Avatar = x.Avatar,
                    CitizenId = x.CitizenId,
                    //PasswordHash = x.PasswordHash,
                    //Salt = x.Salt,
                    Address = x.Address
                });
                var result = new Paginator<User>()
                {
                    TotalRecords = await data.CountAsync(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = await data.ToListAsync()
                };
                return result;
            }
        }

        #region Engines
        private DbSet<User> GettingBy(DbSet<User> query, UserFilter filter)
        {
            if (filter.UserId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.UserId.CompareTo(filter.UserId) == 0);
            }
            if (string.IsNullOrEmpty(filter.Username))
            {
                query.Where(x => x.Username.Equals(filter.Username));
            }
            return query;
        }

        private DbSet<User> Filtering(DbSet<User> query, UserFilter filter)
        {
            query.Where(x => x.DateOfBirth.CompareTo(filter.DateOfBirthFrom) >= 0);
            if (DateTime.Compare(filter.DateOfBirthTo, filter.DateOfBirthFrom) > 0)
            {
                query.Where(x => x.DateOfBirth.CompareTo(filter.DateOfBirthTo) <= 0);
            }
            query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateFrom) >= 0);
            if (DateTime.Compare(filter.CreatedDateTo, filter.CreatedDateFrom) > 0)
            {
                query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateTo) <= 0);
            }
            if (filter.Gender.HasValue)
            {
                query.Where(x => x.Gender.CompareTo(filter.Gender) == 0);
            }
            return query;
        }

        private DbSet<User> Searching(DbSet<User> query, UserFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.UserId.ToString().Contains(filter.Keyword) ||
                        x.FirstName.ToString().Contains(filter.Keyword) ||
                        x.MiddleName.ToString().Contains(filter.Keyword) ||
                        x.LastName.ToString().Contains(filter.Keyword) ||
                        x.Username.ToString().Contains(filter.Keyword) ||
                        x.DisplayName.ToString().Contains(filter.Keyword) ||
                        x.PhoneNumber.ToString().Contains(filter.Keyword) ||
                        x.Email.ToString().Contains(filter.Keyword) ||
                        x.CitizenId.ToString().Contains(filter.Keyword) ||
                        x.Address.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.UserId.ToString().Equals(filter.Keyword) ||
                        x.FirstName.ToString().Equals(filter.Keyword) ||
                        x.MiddleName.ToString().Equals(filter.Keyword) ||
                        x.LastName.ToString().Equals(filter.Keyword) ||
                        x.Username.ToString().Equals(filter.Keyword) ||
                        x.DisplayName.ToString().Equals(filter.Keyword) ||
                        x.PhoneNumber.ToString().Equals(filter.Keyword) ||
                        x.Email.ToString().Equals(filter.Keyword) ||
                        x.CitizenId.ToString().Equals(filter.Keyword) ||
                        x.Address.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<User> Paging(DbSet<User> query, UserFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<User> Sorting(DbSet<User> query, UserFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.CreatedDate);
            }
            else
            {
                query.OrderByDescending(x => x.CreatedDate);
            }
            return query;
        }
        #endregion

        public async Task<bool> UpdateUser(User user)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Users.FindAsync(user.UserId);
                //data.UserId = user.UserId;
                data.FirstName = user.FirstName;
                data.MiddleName = user.MiddleName;
                data.LastName = user.LastName;
                data.Username = user.Username;
                data.DisplayName = user.DisplayName;
                data.PhoneNumber = user.PhoneNumber;
                data.Email = user.Email;
                data.DateOfBirth = user.DateOfBirth;
                //data.CreatedDate = user.CreatedDate;
                //data.PasswordHash = user.PasswordHash;
                data.Gender = user.Gender;
                //data.Avatar = user.Avatar;
                data.CitizenId = user.CitizenId;
                data.Address = user.Address;
                //data.Salt = user.Salt;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> UpdatePassword(Guid userId, string password)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Users.FindAsync(userId);
                Tuple<string, string> encryptor = Encryptor.Instance.HashPassword(password);
                data.Salt = encryptor.Item1;
                data.PasswordHash = encryptor.Item2;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> UpdateAvatar(Guid userId, string avatarPath = null)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Users.FindAsync(userId);
                if (string.IsNullOrEmpty(avatarPath))
                {
                    data.Avatar = DataTypeConvertor.Instance.EncryptDefaultAvatar();
                }
                else
                {
                    data.Avatar = DataTypeConvertor.Instance.GetImageFromBytes(avatarPath);
                }
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> CheckPassword(string username, string password)
        {
            using (var context = new ZiDbContext())
            {
                var user = await context.Users.Where(x => x.Username.Equals(username)).FirstAsync();
                if (!Encryptor.Instance.IsMatchedPassword(password, user.PasswordHash))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
