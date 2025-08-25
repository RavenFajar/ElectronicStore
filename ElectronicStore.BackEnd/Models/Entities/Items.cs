using ElectronicStore.BackEnd.Models.Enum;

namespace ElectronicStore.BackEnd.Entities;

public class Items
{
    public Guid Id { get; set; }
    public ItemTypes ItemTypes { get; set; }
    public required string ItemCode { get; set; }
    public required string Name { get; set; }
    public required double Length { get; set; }
    public required double Width { get; set; }
    public required double Height { get; set; }
    public required Int64 Price { get; set; }
    public bool IsDiscount { get; set; }
    public double Discount { get; set; }
    public required string Description { get; set; }
    public required string Picture { get; set; }
    public bool IsDelete { get; set; }
}