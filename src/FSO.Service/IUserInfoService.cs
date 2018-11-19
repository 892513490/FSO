using FSO.Models;
using FSO.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Service
{
    public interface IUserInfoService
    {
        Task<List<UserInfo>> GetUserInfos();
    }
}
