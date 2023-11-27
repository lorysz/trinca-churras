using Microsoft.Azure.Cosmos;

namespace TrincaChurras.API
{
    public static class ServiceCollectionExtensions
    {
        private const string DATABASE = "DbChurrasco";

        public static IServiceCollection AddEventStore(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["CosmosDb:ConnectionString"];

            var client = new CosmosClient(connectionString);

            InitializeDatabaseAsync(client).GetAwaiter().GetResult();

            return services;
        }

        private static async Task InitializeDatabaseAsync(CosmosClient client)
        {
            var databaseResponse = await client.CreateDatabaseIfNotExistsAsync(DATABASE);

            await CreateContainerIfNotExistsAsync(databaseResponse.Database, "Churrascos");
            await CreateContainerIfNotExistsAsync(databaseResponse.Database, "Users");
        }

        private static async Task CreateContainerIfNotExistsAsync(Database database, string containerName)
        {
            await database.CreateContainerIfNotExistsAsync(new ContainerProperties(containerName, "/StreamId"));
        }
    }

}
