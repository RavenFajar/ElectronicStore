namespace ElectronicStore.BackEnd.Entities;

public class InvoiceDetails
{
    public required Guid Id { get; set; }
    public required Guid InvoiceId { get; set; }
    public required Guid ItemId { get; set; }
    public required int Quantity { get; set; }
    public required int Price { get; set; }
    public required bool IsDeleted { get; set; } 
}