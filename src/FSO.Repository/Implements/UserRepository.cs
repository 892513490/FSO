using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FSO.Models;
using Microsoft.EntityFrameworkCore;

namespace FSO.Repository.Implements
{
    public class UserRepository : IUserRepository
    {
        private MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<List<UserInfo>> GetUserInfos()
        {
            return await _context.UserInfos.ToListAsync();
        }
    }
}
