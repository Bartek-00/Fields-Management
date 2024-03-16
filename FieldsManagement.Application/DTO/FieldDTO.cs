using FieldsManagement.Core.Entities;

namespace FieldsManagement.Application.DTO;

public class FieldDTO
{
    public Guid FieldId { get; set; }

    public string VillageName { get; set; }
    public double Area { get; set; }
    public string AdditionalData { get; set; }
    public List<Operation> Actions { get; set; }
}