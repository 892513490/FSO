using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FSO.Models;
using Microsoft.EntityFrameworkCore;

namespace FSO.Repository.Implements
{
    public class VedioInfoRepository<T> : BaseRepository<T>, IVideoInfoRepository<T> where T: VideoInfo
    {
        public VedioInfoRepository(MySqlContext context) : base(context)
        {
        }
    }
}
