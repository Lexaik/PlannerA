using Microsoft.Extensions.Configuration;

namespace PlannerA.DAL;

public class AppContext
{
    static IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    public static readonly string connectionString = configuration.GetConnectionString("DefaultConnection");
}