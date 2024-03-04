namespace FieldsManagement.Core.Entities;

public class Fields
{
    public Fields(string id, string villageName, double area, string additionalData)
    {
        Id = id;
        VillageName = villageName;
        Area = area;
        AdditionalData = additionalData;
    }

    public string Id { get; set; }
    public string VillageName { get; set; }
    public double Area { get; set; }
    public string AdditionalData { get; set; }
}