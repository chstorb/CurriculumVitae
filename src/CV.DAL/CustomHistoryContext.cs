using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Web;

namespace CV.DAL
{
    using CV.Common;

    /// <summary>
    /// CustomHistoryContext class.
    /// </summary>
    public class CustomHistoryContext : HistoryContext
    {
        public CustomHistoryContext(DbConnection dbConnection, string defaultSchema)
            : base(dbConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().ToTable(tableName: Constants.TablePrefix + "MigrationHistory");
        }
    } 
}