using Daroya.MoneymeAPI.Models.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Daroya.MoneymeAPI.Database
{
    public class MoneyMeContext : DbContext
    {
        public MoneyMeContext(DbContextOptions<MoneyMeContext> options)
        : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=blogging.db");
    }
}
