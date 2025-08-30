namespace ElectronicStore.BackEnd.Entities;

public sealed class InvoiceDetails
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public bool IsDelete { get; set; } 
}