namespace ElectronicStore.BackEnd.Entities;

public sealed class Invoice
{
    public Guid Id { get; set; }
    public DateTimeOffset InvoiceDate { get; set; }
    public int LabourPrice { get; set; }
    public Int64 GrandPrice { get; set; }
    public List<InvoiceDetails> InvoiceDetails { get; set; } = new();
    public byte[]? RowVersion { get; set; }

}