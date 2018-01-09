using Microsoft.Extensions.Configuration;

namespace FBS.DataAccess
{
    public class DataAccessBase
    {
        protected string connectionString = "";

        public DataAccessBase(IConfiguration configuration)
        {
            this.connectionString = configuration["ConnectionSettings:ConnectionString"];
        }
    }
}
