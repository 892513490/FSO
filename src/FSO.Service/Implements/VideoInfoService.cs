using FSO.Models;
using FSO.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FSO.Service.Implements
{
    public class VideoInfoService : IVideoInfoService
    {
        private IVideoInfoRepository<VideoInfo> _repository;

        public VideoInfoService(IVideoInfoRepository<VideoInfo> repository)
        {
            _repository = repository;
        }

        public void Add(VideoInfo videoInfo)
        {
            _repository.Add(videoInfo);
        }

        public void AddRange(IList<VideoInfo> list)
        {
            _repository.AddRange(list);
        }

        public void Update(VideoInfo videoInfo)
        {
            _repository.Update(videoInfo);
        }

        public void Delete(long id)
        {
            var entry = _repository.SingleOrDefault(item => item.Id.Equals(id));
            _repository.Remove(entry);
        }

        public VideoInfo Get(long id)
        {
            return _repository.FirstOrDefault(item=>item.Id.Equals(id));
        }

        public IList<VideoInfo> GetList(Expression<Func<VideoInfo, bool>> predicate = null)
        {
            return _repository.GetList<VideoInfo>(predicate:predicate);
        }
    }
}
