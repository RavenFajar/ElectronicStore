using ElectronicStore.BackEnd.Entities;

namespace ElectronicStore.BackEnd.Models.Dto;

public sealed record class UpdateInvoiceDetailsDto
{
    public required Guid Id { get; set; }
    public required Guid InvoiceId { get; set; }
    public required Guid ItemId { get; set; }
    public required int Quantity { get; set; }
    public required int Price { get; set; }
    public required bool IsDeleted { get; set; }
}