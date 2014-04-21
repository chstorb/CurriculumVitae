using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace CV.DAL
{
    using System.Data.Entity.Infrastructure.Interception;
    using CV.Diagnostics;

    /// <summary>
    /// CustomDbConfiguration class.
    /// </summary>
    public class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            SetHistoryContext("System.Data.SqlClient", (connection, defaultSchema) => new CustomHistoryContext(connection, defaultSchema));

            // Enable connection resiliency
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
#if DEBUG
            DbInterception.Add(new CustomDbCommandInterceptor());
            DbInterception.Add(new TransientErrorDbCommandInterceptor());
#endif
        }
    }
}