using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.LinqSqlLayer.Engines.Encoders;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class UserService : IUserService
    {
        public bool AddUser(UserDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var user = new User()
                {
                    UserId = obj.UserId,
                    FirstName = obj.FirstName,
                    MiddleName = obj.MiddleName,
                    LastName = obj.LastName,
                    Username = obj.Username,
                    DisplayName = obj.DisplayName,
                    PhoneNumber = obj.PhoneNumber,
                    Email = obj.Email,
                    DateOfBirth = obj.DateOfBirth,
                    CreatedDate = obj.CreatedDate,
                    Gender = (int)obj.Gender,
                    CitizenId = obj.CitizenId,
                    Address = obj.Address
                };
                context.Users.InsertOnSubmit(user);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteUser(Guid userId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users.Where(x => x.UserId.CompareTo(userId) == 0).FirstOrDefault();
                context.Users.DeleteOnSubmit(user);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<UserDTO> GetUsers(UserFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Users;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Use to mapping data
                var data = query.Select(x => new UserDTO()
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
                    Gender = (Genders)x.Gender,
                    Avatar = x.Avatar.ToArray(),
                    CitizenId = x.CitizenId,
                    //PasswordHash = x.PasswordHash,
                    //Salt = x.Salt,
                    Address = x.Address
                });
                var result = new Paginator<UserDTO>()
                {
                    TotalRecords = data.Count(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                return result;
            }
        }

        #region Engines
        private Table<User> GettingBy(Table<User> query, UserFilter filter)
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

        private Table<User> Filtering(Table<User> query, UserFilter filter)
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

        private Table<User> Searching(Table<User> query, UserFilter filter)
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

        private Table<User> Paging(Table<User> query, UserFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<User> Sorting(Table<User> query, UserFilter filter)
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

        public bool UpdateUser(UserDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users.Where(x => x.UserId.CompareTo(obj.UserId) == 0).FirstOrDefault();
                //user.UserId = obj.UserId;
                user.FirstName = obj.FirstName;
                user.MiddleName = obj.MiddleName;
                user.LastName = obj.LastName;
                user.Username = obj.Username;
                user.DisplayName = obj.DisplayName;
                user.PhoneNumber = obj.PhoneNumber;
                user.Email = obj.Email;
                user.DateOfBirth = obj.DateOfBirth;
                //user.CreatedDate = obj.CreatedDate;
                //user.PasswordHash = obj.PasswordHash;
                user.Gender = (int)obj.Gender;
                //user.Avatar = obj.Avatar;
                user.CitizenId = obj.CitizenId;
                user.Address = obj.Address;
                //user.Salt = obj.Salt;
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool UpdatePassword(Guid userId, string password)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users.Where(x => x.UserId.CompareTo(userId) == 0).FirstOrDefault();
                Tuple<string, string> encryptor = Encryptor.Instance.HashPassword(password);
                user.Salt = encryptor.Item1;
                user.PasswordHash = encryptor.Item2;
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool UpdateAvatar(Guid userId, string avatarPath = null)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users.Where(x => x.UserId.CompareTo(userId) == 0).FirstOrDefault();
                if (string.IsNullOrEmpty(avatarPath))
                {
                    user.Avatar = DataTypeConvertor.Instance.EncryptDefaultAvatar();
                }
                else
                {
                    user.Avatar = DataTypeConvertor.Instance.GetImageFromBytes(avatarPath);
                }
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool CheckPassword(string username, string password)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
                if (!Encryptor.Instance.IsMatchedPassword(password, user.PasswordHash))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
