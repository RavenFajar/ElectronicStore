namespace ElectronicStore.BackEnd.Models.Dto;

public class UpdateItemDto
{
    public required string ItemCode { get; set; }
    public required string Name { get; set; }
    public required double Length { get; set; }
    public required double Width { get; set; }
    public required double Height { get; set; }
    public required Int64 Price { get; set; }
    public required string Description { get; set; }
    public required string Picture { get; set; }
    
}