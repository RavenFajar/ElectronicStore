using ElectronicStore.BackEnd.Entities;

namespace ElectronicStore.BackEnd.Models.Dto;

public sealed class AddInvoiceDetailsDto
{
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public int Discount { get; set; }
}