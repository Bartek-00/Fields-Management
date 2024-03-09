using MySpot.Core.ValueObjects;

namespace FieldsManagement.Core.Entities;

public class Field
{
    public Field(Guid fieldId, string villageName, double area, string additionalData)
    {
        FieldId = fieldId;
        VillageName = villageName;
        Area = area;
        AdditionalData = additionalData;
    }

    public FieldId FieldId { get; private set; }
    public string VillageName { get; private set; }
    public double Area { get; private set; }
    public string AdditionalData { get; private set; }
    private List<Action> Actions { get; set; }
}