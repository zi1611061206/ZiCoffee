using System;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.LinqSqlLayer.Engines.Encoders;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class UserService : IUserService
    {
        #region Instance
        private static UserService instance;
        public static UserService Instance
        {
            get { if (instance == null) instance = new UserService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private UserService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(UserModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = new User()
                {
                    UserId = model.UserId,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Username = model.Username,
                    DisplayName = model.DisplayName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    CreatedDate = model.CreatedDate,
                    Gender = (int)model.Gender,
                    CitizenId = model.CitizenId,
                    Address = model.Address
                };
                context.Users.InsertOnSubmit(user);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, user.UserId);
            }
        }

        public Tuple<bool, object> Delete(Guid userId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users
                    .Where(x => x.UserId.CompareTo(userId) == 0)
                    .FirstOrDefault();
                if (user == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + userId);
                }
                context.Users.DeleteOnSubmit(user);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedDelete", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Read(UserFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Users;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Use to mapping data
                var data = query.Select(x => new UserModel()
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
                var result = new Paginator<UserModel>()
                {
                    TotalRecords = data.Count(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                if (data.Count() <= 0)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                return new Tuple<bool, object>(true, result);
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

        public Tuple<bool, object> Update(UserModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users
                    .Where(x => x.UserId.CompareTo(model.UserId) == 0)
                    .FirstOrDefault();
                if (user == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.UserId);
                }
                //user.UserId = model.UserId;
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.Username = model.Username;
                user.DisplayName = model.DisplayName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.DateOfBirth = model.DateOfBirth;
                //user.CreatedDate = model.CreatedDate;
                //user.PasswordHash = model.PasswordHash;
                user.Gender = (int)model.Gender;
                //user.Avatar = model.Avatar;
                user.CitizenId = model.CitizenId;
                user.Address = model.Address;
                //user.Salt = model.Salt;

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedUpdate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> UpdatePassword(Guid userId, string password, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users
                    .Where(x => x.UserId.CompareTo(userId) == 0)
                    .FirstOrDefault();
                if (user == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + userId);
                }
                Tuple<string, string> encryptor = Encryptor.Instance.HashPassword(password);
                user.Salt = encryptor.Item1;
                user.PasswordHash = encryptor.Item2;

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedUpdate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> UpdateAvatar(Guid userId, string cultureName, string avatarPath = null)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users
                    .Where(x => x.UserId.CompareTo(userId) == 0)
                    .FirstOrDefault();
                if (user == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + userId);
                }
                if (string.IsNullOrEmpty(avatarPath))
                {
                    user.Avatar = DataTypeConvertor.Instance.EncryptDefaultAvatar();
                }
                else
                {
                    user.Avatar = DataTypeConvertor.Instance.GetBytesFromImage(avatarPath);
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedUpdate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> ExistedUsername(string username, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users
                    .Where(x => x.Username.Equals(username))
                    .FirstOrDefault();
                if (user == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotExistedUsername", culture));
                }
                return new Tuple<bool, object>(true, Rm.GetString("ExistedUsername", culture));
            }
        }

        public Tuple<bool, object> MatchedPassword(string username, string password, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users
                    .Where(x => x.Username.Equals(username))
                    .FirstOrDefault();
                if (!Encryptor.Instance.IsMatchedPassword(password, user.PasswordHash))
                {
                    return new Tuple<bool, object>(false, Rm.GetString("WrongPassword", culture));
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> ExistedCitizenId(string citizenId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var user = context.Users
                    .Where(x => x.CitizenId.Equals(citizenId))
                    .FirstOrDefault();
                if (user == null)
                {
                    return new Tuple<bool, object>(false, null);
                }
                return new Tuple<bool, object>(true, Rm.GetString("ExistedCitizenId", culture));
            }
        }
    }
}
