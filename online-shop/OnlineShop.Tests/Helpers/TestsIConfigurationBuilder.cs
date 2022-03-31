using Microsoft.Extensions.Configuration;

namespace OnlineShop.Tests.Helpers
{
    public class TestsIConfigurationBuilder
    {
        public static IConfigurationRoot GetIConfigurationRoot()
        {                
            return new ConfigurationBuilder()
                .SetBasePath("D:\\Projects\\OnlineShop\\online-shop\\online-shop")
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}