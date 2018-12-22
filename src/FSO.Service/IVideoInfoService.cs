using FSO.Models;
using FSO.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Service
{
    public interface IVideoInfoService
    {
        void Add(VideoInfo videoInfo);

        void AddRange(IList<VideoInfo> list);

        void Delete(long id);

        void Update(VideoInfo urlInfo);

        VideoInfo Get(long id);

        IList<VideoInfo> GetList(Expression<Func<VideoInfo, bool>> predicate = null);
    }
}
