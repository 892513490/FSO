using FSO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSO.Repository
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        
        public DbSet<UrlInfo> UrlInfos { get; set; }

        public DbSet<VideoInfo> VideoInfos { get; set; }

        //重写OnConfiguring方法
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source=.;user id=sa;pwd=123456;database=FSO");
        //}
    }
}
