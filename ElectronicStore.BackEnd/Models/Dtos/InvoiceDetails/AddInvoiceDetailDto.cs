using ElectronicStore.BackEnd.Entities;

namespace ElectronicStore.BackEnd.Models.Dto;

public sealed record class AddInvoiceDetailsDto
{
    public Guid InvoiceId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}