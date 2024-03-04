#nullable disable

namespace FieldsManagement.Infrastructure.InfrastructureModel;

public class DataBaseConfiguration
{
    public string MongoDbConnectionString { get; set; }
    public string MongoDatabaseName { get; set; }
}