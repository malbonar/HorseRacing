using MBSoftware.HorseRacing.Core.DAL;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace MBSoftware.HorseRacing.Core.DataServices
{
    public class DbContextProvider : IDbContextFactory
    {
        private readonly ConnectionStringConfig _connectionStrings;

        /// <summary>
        /// Connection string to db is fetched via access to configuration setup in Startup class from this line:
        /// services.Configure<ConnectionStringConfig>(Configuration.GetSection("connectionStrings"));
        /// Uses the Options pattern for accessing strongly typed config settings
        /// </summary>
        public DbContextProvider(IOptions<ConnectionStringConfig> connStrProvider)
        {
            if (connStrProvider == null)
                throw new ArgumentNullException(nameof(connStrProvider));

            _connectionStrings = connStrProvider.Value;
        }

        /// <summary>
        /// Access db via IOptions ctor param that points to SqlServer connection string from config option
        /// </summary>
        /// <returns>DbContext for database described in config</returns>
        public AzureHorseRatingsDbContext GetHorseRatingsDbContext()
        {
            return new AzureHorseRatingsDbContext(new DbContextOptionsBuilder<AzureHorseRatingsDbContext>()
                    .UseSqlServer(_connectionStrings.AppDbConnection)
                    .Options);
        }
    }
}
