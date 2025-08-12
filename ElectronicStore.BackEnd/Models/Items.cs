namespace ElectronicStore.BackEnd.Models;

public sealed class Items
{
    public Guid Id { get; set; }
    public required string ItemCode { get; set; }
    public required string Name { get; set; }
    public required int Length { get; set; }
    public required int Width { get; set; }
    public required int Height { get; set; }
    public required Int64 Price { get; set; }
    public required string Description { get; set; }
    public required string Picture { get; set; }
    public byte[]? RowVersion { get; set; }
}