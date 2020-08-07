using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MBSoftware.HorseRacing.Core.DAL
{
    //public partial class AzureHorseRatingsDbContextPartial : DbContext
    //{
    //    /// <summary>
    //    /// If parameterless ctor is used then this will load the database from app.config file.
    //    /// This Web-API uses the options to pass in the connection string
    //    /// </summary>
    //    /// <param name="optionsBuilder">Options containing the connection string</param>
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        if (!optionsBuilder.IsConfigured)
    //        {
    //            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["HorseRacingSqlServerConnectionString"],
    //                sqlServerOptions => sqlServerOptions.CommandTimeout(90));
    //        }
    //    }
    //}
}
