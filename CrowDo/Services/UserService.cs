using CrowDo.Models;
using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCrm.Core.Data;

namespace CrowDo.Services
{
    public class UserService : IUserServive

    {
        private TinyCrmDbContext context;

        public UserService(TinyCrmDbContext dbContext)
        {
            context = dbContext;
        }
        public User CreateUser(CreateUserOptions userOptions)
        {

            if (userOptions == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(userOptions.FirstName) ||
                string.IsNullOrWhiteSpace(userOptions.LastName) ||
                string.IsNullOrWhiteSpace(userOptions.Address) ||
                string.IsNullOrWhiteSpace(userOptions.Email) ||
                !userOptions.Email.Contains("@") ||
                !userOptions.DateOfBirthYear.HasValue ||
                !userOptions.DateOfBirthMonth.HasValue ||
                !userOptions.DateOfBirthDay.HasValue
                )
            {
                return null;
            }

            var user = new User
            {
                FirstName = userOptions.FirstName,
                LastName = userOptions.LastName,
                Address = userOptions.Address,
                Email = userOptions.Email,
                DateOfBirthYear = userOptions.DateOfBirthYear,
                DateOfBirthMonth= userOptions.DateOfBirthMonth,
                DateOfBirthDay = userOptions.DateOfBirthDay
            };

            context.Set<User>().Add(user);
            context.SaveChanges();
            return user;
        }

        public IQueryable<User> Search(SearchUserOptions userOptions)
        {
            if (userOptions == null)
            {
                return null;
            }

            var query = context
               .Set<User>()
               .AsQueryable();

            if (userOptions.Id != null)
            {
                query = query.Where(
                    c => c.Id == userOptions.Id);
            }

            if (!string.IsNullOrWhiteSpace(userOptions.FirstName))
            {
                query = query
                      .Where(c => c.FirstName.Contains(userOptions.FirstName));
            }

            if (userOptions.LastName != null)
            {
                query = query
                        .Where(c => c.LastName == userOptions.LastName);
            }

            if (userOptions.Address != null)
            {
                query = query
                        .Where(c => c.Address == userOptions.Address);
            }

            if (userOptions.Email != null ||
                userOptions.Email.Contains("@"))
            {
                query = query
                        .Where(c => c.Email == userOptions.Email);
            }

            if (userOptions.DateOfBirthYear != null)
            {
                query = query
                        .Where(c => c.DateOfBirthYear == userOptions.DateOfBirthYear);
            }

            if (userOptions.DateOfBirthMonth != null)
            {
                query = query
                        .Where(c => c.DateOfBirthMonth == userOptions.DateOfBirthMonth);
            }

            if (userOptions.DateOfBirthDay != null)
            {
                query = query
                        .Where(c => c.DateOfBirthDay == userOptions.DateOfBirthDay);
            }

             return query;
        }

        public User GetUserById(int id)
        {
            var user = context
                .Set<User>()
                .SingleOrDefault(s => s.Id == id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public bool UpdateUser(int id,
            UpdateUserOptions options)
        {
            if (options == null)
            {
                return false;
            }

            var user = GetUserById(id);
            if (user == null)
            {
                return false;
            }
            
            if (!string.IsNullOrWhiteSpace(options.FirstName))
            {
                user.FirstName = options.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(options.LastName))
            {
                user.LastName = options.LastName;
            }

            if (!string.IsNullOrWhiteSpace(options.Address))
            {
                user.Address = options.Address;
            }

            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                user.FirstName = options.FirstName;
            }

            if (options.DateOfBirthYear != null)
            {
                user.DateOfBirthYear = options.DateOfBirthYear;
            }

            if (options.DateOfBirthMonth != null)
            {
                user.DateOfBirthMonth = options.DateOfBirthMonth;
            }

            if (options.DateOfBirthDay != null)
            {
                user.DateOfBirthDay = options.DateOfBirthDay;
            }
            
            return true;
        }
    }
}
