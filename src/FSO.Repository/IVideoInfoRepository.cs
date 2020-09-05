using FSO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Repository
{
    public interface IVideoInfoRepository<T> : IBaseRepository<T> where T: VideoInfo
    {
        
    }
}
