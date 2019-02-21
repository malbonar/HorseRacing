using MBSoftware.HorseRacing.Core.DAL;


namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    /// <summary>
    /// Interface to generate a db context that the data services can use.
    /// Saves repeating the code to create the db context.
    /// Interface allows the implementing class to be injected into the data service classes via DI by the startup class
    /// </summary>
    public interface IDbContextFactory
    {
        /// <summary>
        /// Creates and returns an instance of the db context
        /// </summary>
        /// <returns>Horse ratings db context</returns>
        AzureHorseRatingsDbContext GetHorseRatingsDbContext();
    }
}
