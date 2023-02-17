using System.Text;

namespace MotoApp.Data.Entities;

internal class Car : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal Cost { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Id: {Id,3} | Name: {Name}");
        sb.AppendLine($"\tColor: {Color}");
        sb.AppendLine($"\tPrice: {Cost}");
        sb.AppendLine($"\tType: {Type}");

        return sb.ToString();
    }
}
