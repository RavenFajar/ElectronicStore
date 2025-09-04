using ElectronicStore.BackEnd.Entities;

namespace ElectronicStore.BackEnd.Models.Dto;

public sealed record class UpdateInvoiceDetailsDto
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public Guid ItemId { get; set; }
    public Items Item { get; set; } = null!;
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public int Discount { get; set; }
    public List<Items> Items { get; set; } = new List<Items>();
    public byte[]? RowVersion { get; set; }
}