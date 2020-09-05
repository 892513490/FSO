using FSO.Models;
using FSO.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Service
{
    public interface IUrlInfoService
    {
        void Add(UrlInfo urlInfo);

        void AddRange(IList<UrlInfo> list);

        void Delete(long id);

        void Update(UrlInfo urlInfo);

        UrlInfo Get(long id);

        IList<UrlInfo> GetList();
    }
}
