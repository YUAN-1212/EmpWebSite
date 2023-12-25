using System.Configuration;
using System.Data.Entity;
using System.Data.Common;
using Domain.Model;

namespace Domain
{
    /*
     需安裝以下 NuGet:
     1.SQLite
     2.System.Data.SQLite
     3.System.Data.SQLite.EF6
     */

    public class WebDbContext : DbContext
    {
        public WebDbContext() : base(GetConnection(), false)
        {
            Database.SetInitializer<WebDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        public static DbConnection GetConnection()
        {
            // 取得 Sqlite 連線字串
            var connection = ConfigurationManager.ConnectionStrings["DB"];
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            dbCon.ConnectionString = connection.ConnectionString;
            return dbCon;
        }

        #region TABLES
        /// <summary>
        /// 部門
        /// </summary>
        public DbSet<Dept> Depts { get; set; }

        /// <summary>
        /// 員工
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public DbSet<ZipCode> ZipCodes { get; set; }
        #endregion
    }
}
