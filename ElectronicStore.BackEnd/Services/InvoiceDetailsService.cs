using ElectronicStore.BackEnd.Repository;

namespace ElectronicStore.BackEnd.Services;

public interface IInvoiceDetails
{
    Task<IEnumerable<InvoiceDetails>> GetInvoiceDetailsAsyncAsync();
    // Task<InvoiceDetails> GetItemByIdAsync(Guid id);
    // Task<InvoiceDetails> AddItemAsync();
    // Task<bool> DeleteItemAsync(Guid id);
    // Task<InvoiceDetails> UpdateItemAsync();
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
    // public async Task<InvoiceDetails> GetItemByIdAsync(Guid id)
    // {
    //     var invoice = await _invoiceDetailsRepository.GetInvoiceDetailByIdAsync(id);
    //     if (invoice is not null)
    //     {
    //         return invoice;
    //     }
    //     else
    //     {

    //     }
    // }
}