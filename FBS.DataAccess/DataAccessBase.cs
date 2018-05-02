using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FBS.DataAccess
{
    public class DataAccessBase
    {
        protected readonly ILogger<DataAccessBase> logger;
        protected string connectionString = "";

        public DataAccessBase(IConfiguration configuration, ILogger<DataAccessBase> logger)
        {
            logger.LogInformation("In base constructor");
            logger.LogInformation("Configuration connection string: " + configuration["ConnectionSettings:ConnectionString"]);
            this.logger = logger;
            this.connectionString = configuration["ConnectionSettings:ConnectionString"];
        }
    }
}
