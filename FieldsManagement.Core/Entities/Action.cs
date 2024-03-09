namespace FieldsManagement.Core.Entities;

public class Action
{
    public Action(Guid id, string name, string description, DateTime date)
    {
        Id = id;
        Name = name;
        Description = description;
        Date = date;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
}