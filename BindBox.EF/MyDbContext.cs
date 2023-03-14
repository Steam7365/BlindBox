using BindBox.Models;
using Microsoft.EntityFrameworkCore;

namespace BindBox.EF
{
    public class MyDbContext : DbContext
    {
        public DbSet<AddressInfo> AddressInfos { get; set; }
        public DbSet<BoxCommodity> BoxCommodities { get; set; }
        public DbSet<BoxFolder> BoxFolders { get; set; }
        public DbSet<CommdityDetail> CommdityDetails { get; set; }
        public DbSet<DescribeType> DescribeTypes { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
