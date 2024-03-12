using System.ComponentModel.DataAnnotations;

public class ConnectionStringsSettings
{
    public const string SectionName = "ConnectionStrings";

    [Required]
    public string? MongoDb { get; set; }
}