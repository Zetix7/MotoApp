namespace MotoApp.Data.Entities;

internal class BusinessPartner : EntityBase
{
    public string? Name { get; set; }

    public override string ToString() => $"Id: {Id} | Name: {Name}";
}
