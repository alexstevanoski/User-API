// MongoDbSettings.cs
namespace UserAPI.DataContext;
public class MongoDbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}