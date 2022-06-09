using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
       
        private MultiDbContext multiDbContext { get => _db as MultiDbContext; }
        public UserRepository(MultiDbContext db) : base(db)
        {
        }

        public User UserFindById (int userId)
        {

            return multiDbContext.Users.Find(userId)!;
        }

        public void AddUser(User user)
        {
            multiDbContext.Users.Add(user);
        }

        public User FindByEmailPassword(string email, string password)
        {
            return multiDbContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password)!;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newUser = UserFindById(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(60);
        }

        public User GetUserWithRefreshToken(string refreshToken)
        {
            return multiDbContext.Users.FirstOrDefault(s => s.RefreshToken == refreshToken)!;
        }

        public void RemoveREfreshToken(User user)
        {
            User newUser = UserFindById(user.Id);
            newUser.RefreshToken = null;
            newUser.RefreshTokenEndDate = null;
        }
    }
}
