using FSO.Models;
using FSO.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FSO.Service.Implements
{
    public class UrlInfoService : IUrlInfoService
    {
        private IUrlRepository<UrlInfo> _repository;

        public UrlInfoService(IUrlRepository<UrlInfo> repository)
        {
            _repository = repository;
        }

        public void Add(UrlInfo urlInfo)
        {
            _repository.Add(urlInfo);
        }

        public void AddRange(IList<UrlInfo> list)
        {
            _repository.AddRange(list);
        }

        public void Update(UrlInfo urlInfo)
        {
            _repository.Update(urlInfo);
        }

        public void Delete(long id)
        {
            var entry = _repository.SingleOrDefault(item => item.Id.Equals(id));
            _repository.Remove(entry);
        }

        public UrlInfo Get(long id)
        {
            return _repository.FirstOrDefault(item=>item.Id.Equals(id));
        }

        public IList<UrlInfo> GetList()
        {
            return _repository.GetList<UrlInfo>();
        }
    }
}
