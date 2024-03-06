namespace FieldsManagement.Core.Entities;

public class Fields
{
    public Fields(Guid id, string villageName, double area, string additionalData)
    {
        Id = id;
        VillageName = villageName;
        Area = area;
        AdditionalData = additionalData;
    }

    public Guid Id { get; private set; }
    public string VillageName { get; private set; }
    public double Area { get; private set; }
    public string AdditionalData { get; private set; }
}