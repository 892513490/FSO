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
    public class UrlRepository<T> : BaseRepository<T>, IUrlRepository<T> where T: UrlInfo
    {
        public UrlRepository(MySqlContext context) : base(context)
        {
        }
    }
}
