using CrowDo.Models;
using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowDo.Core.Data;

namespace CrowDo.Services
{
    public class UserService : IUserService

    {
        private CrowDoDbContext context;

        public UserService(CrowDoDbContext dbContext)
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
                !userOptions.YearOfBirth.HasValue)
            {
                return null;
            }

            var user = new User
            {
                FirstName = userOptions.FirstName,
                LastName = userOptions.LastName,
                Address = userOptions.Address,
                Email = userOptions.Email,
                YearOfBirth = userOptions.YearOfBirth,
              
            };

            context.Set<User>().Add(user);
            context.SaveChanges();
            return user;
        }

        public IQueryable<User> SearchUser(SearchUserOptions userOptions)
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

            if (userOptions.YearOfBirth != null)
            {
                query = query
                        .Where(c => c.YearOfBirth == userOptions.YearOfBirth);
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

            if (options.YearOfBirth != null)
            {
                user.YearOfBirth = options.YearOfBirth;
            }

   
            return true;
        }
    }
}
