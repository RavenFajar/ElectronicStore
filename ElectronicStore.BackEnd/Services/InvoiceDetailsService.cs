using ElectronicStore.BackEnd.Models.Dto;
using ElectronicStore.BackEnd.Repository;

namespace ElectronicStore.BackEnd.Services;

public interface IInvoiceDetails
{
    Task<IEnumerable<InvoiceDetails>> GetInvoiceDetailsAsyncAsync();
    Task<Entities.InvoiceDetails> GetItemByIdAsync(Guid id);
    Task<Entities.InvoiceDetails> AddInvoiceDetailAsync(AddInvoiceDetailsDto invoiceDetailRequest);
    Task<bool> DeleteInvoiceDetailAsync(Guid id);
    Task<Entities.InvoiceDetails> UpdateInvoiceDetailAsync(UpdateInvoiceDetailsDto updateRequest);
}
public class InvoiceDetails : IInvoiceDetails
{
    private InvoiceDetailsRepository _invoiceDetailsRepository;
    public InvoiceDetails(InvoiceDetailsRepository invoiceDetailsRepository)
    {
        _invoiceDetailsRepository = invoiceDetailsRepository;
    }
    public async Task<IEnumerable<InvoiceDetails>> GetInvoiceDetailsAsyncAsync()
    {
        var invoices = await _invoiceDetailsRepository.GetAllInvoiceDetailsAsync();
        if (invoices is not null)
        {
            return (IEnumerable<InvoiceDetails>)invoices;
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public async Task<Entities.InvoiceDetails> GetItemByIdAsync(Guid id)
    {
        var invoice = await _invoiceDetailsRepository.GetInvoiceDetailByIdAsync(id);
        if (invoice is not null)
        {
            return invoice;
        }
        else
        {
        throw new ArgumentException();
        }
    }
    public async Task<Entities.InvoiceDetails> AddInvoiceDetailAsync(AddInvoiceDetailsDto invoiceDetailRequest)
    {
        var invoiceDetail = new Entities.InvoiceDetails
        {
            Id = new Guid(),
            InvoiceId = invoiceDetailRequest.InvoiceId,
            ItemId = invoiceDetailRequest.ItemId,
            Quantity = invoiceDetailRequest.Quantity,
            Price = invoiceDetailRequest.Price,
            IsDeleted = false
        };
        var addedInvoiceDetail = await _invoiceDetailsRepository.AddInvoiceDetailAsync(invoiceDetail);
        if (addedInvoiceDetail is not null)
        {
            return addedInvoiceDetail;
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public async Task<bool> DeleteInvoiceDetailAsync(Guid id)
    {
        bool deleteInvoiceDetail = await _invoiceDetailsRepository.DeleteInvoiceDetailAsync(id);
        if (deleteInvoiceDetail)
        {
            return true;
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public async Task<Entities.InvoiceDetails> UpdateInvoiceDetailAsync(UpdateInvoiceDetailsDto updateRequest)
    {
        var updatedInvoiceDetail = new Entities.InvoiceDetails
        {
            Id = updateRequest.Id,
            InvoiceId = updateRequest.InvoiceId,
            ItemId = updateRequest.ItemId,
            Quantity = updateRequest.Quantity,
            Price = updateRequest.Price,
            IsDeleted = updateRequest.IsDeleted
        };
        var result = await _invoiceDetailsRepository.UpdateInvoiceDetailAsync(updatedInvoiceDetail);
        if (result is not null)
        {
            return result;
        }
        else
        {
            throw new ArgumentException();

        }
    }
}