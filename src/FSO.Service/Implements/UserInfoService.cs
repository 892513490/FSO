using FSO.Models;
using FSO.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSO.Service.Implements
{
    public class UserInfoService: IUserInfoService
    {
        private IUserRepository _userRepository;

        public UserInfoService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserInfo>> GetUserInfos()
        {
            return await _userRepository.GetUserInfos();
        }
    }
}
