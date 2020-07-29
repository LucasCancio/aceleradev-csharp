using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;
        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;

            return (from candidate in _context.Candidates
                    join acceleration in _context.Accelerations 
                        on candidate.AccelerationId equals acceleration.Id
                    join user in _context.Users
                        on candidate.UserId equals user.Id
                    where acceleration.Name == name
                    select user)
                    .Distinct()
                    .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return (from user in _context.Users
                    join candidate in _context.Candidates
                       on user.Id equals candidate.UserId
                    where candidate.CompanyId == companyId
                    select user)
                         .Distinct()
                         .ToList();
        }

        public User FindById(int id)
        {
            return _context.Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();
        }

        public User Save(User user)
        {
            var userInDatabase = _context.Users
                                                  .FirstOrDefault(u => u.Id == user.Id);

            bool forCreate = userInDatabase == null;

            User savedUser;
            if (forCreate)
            {
                savedUser = (_context.Users.Add(user)).Entity;
            }
            else
            {
                userInDatabase.FullName = user.FullName ?? userInDatabase.FullName;
                userInDatabase.Email = user.Email ?? userInDatabase.Email;
                userInDatabase.Nickname = user.Nickname ?? userInDatabase.Nickname;
                userInDatabase.Password = user.Password ?? userInDatabase.Password;

                savedUser = (_context.Users.Update(userInDatabase)).Entity;
            }
            _context.SaveChanges();

            return savedUser;
        }
    }
}
