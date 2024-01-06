using MongoDB.Driver;

namespace RedeSocial.Api.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar a conexão de banco de dados
    /// do MongoDB (capturando a connectionstring)
    /// </summary>
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoConnectionString = configuration.GetConnectionString("MongoDB");
            var mongoClient = new MongoClient(mongoConnectionString);

            services.AddSingleton<IMongoClient>(mongoClient);
            services.AddScoped(provider => mongoClient.GetDatabase("RedeSocial"));

            return services;
        }
    }
}