using System.ComponentModel.DataAnnotations;

public class MongoDbSettings
{
    public const string SectionName = "MongoDb";

    [Required]
    public string? DatabaseName { get; set; }

    public bool EnableLogs { get; set; }
}