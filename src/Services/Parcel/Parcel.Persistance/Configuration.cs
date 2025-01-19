using Microsoft.Extensions.Configuration;

namespace Parcel.Persistance
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Parcel.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("ParcelConnectionString");
            }
        }
    }
}
