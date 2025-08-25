namespace ElectronicStore.BackEnd.Repository;

public interface InvoiceDetails
{
    Task GetAllInvoicesDetails();
    Task GetInvoiceDetail();
    Task AddInvoiceDetail();
    Task RemoveInvoiceDetail();
    Task UpdateInvoiceDetail();
}