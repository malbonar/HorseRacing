
namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    /// <summary>
    /// Matches json object structure in appsettings.json
    /// </summary>
    public class ConnectionStringConfig
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        public string AppDbConnection { get; set; }
    }
}
