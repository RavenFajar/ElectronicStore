using ElectronicStore.BackEnd.Entities;

namespace ElectronicStore.BackEnd.Models.Dto;

public sealed class AddInvoiceDto
{
    public DateTimeOffset InvoiceDate { get; set; }
    public int LabourPrice { get; set; }
    public Int64 GrandPrice { get; set; }
    public List<InvoiceDetails> InvoiceDetails { get; set; } = new();
    public byte[]? RowVersion { get; set; }

}