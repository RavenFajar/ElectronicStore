namespace ElectronicStore.BackEnd.Entities;

public sealed class Invoice
{
    public Guid Id { get; set; }
    public DateTimeOffset InvoiceDate { get; set; }
    public int LabourPrice { get; set; }
    public Int64 GrandPrice { get; set; }
    public bool IsDelete { get; set; }
    public required List<InvoiceDetails> InvoiceDetails { get; set; }
}