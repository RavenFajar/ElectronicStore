using ElectronicStore.BackEnd.Models.Enum;

namespace ElectronicStore.BackEnd.Models.Dto;

public sealed record class UpdateItemDto
{
    // Guid Id,
    // ItemTypes ItemTypes,
    // string ItemCode,
    // string Name,
    // double Length,
    // double Width,
    // double Height,
    // Int64 Price,
    // bool IsDiscount,
    // double Discount,
    // string Description,
    // string Picture
    public required Guid Id { get; set; }
    public required ItemTypes ItemTypes { get; set; }
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
}