namespace ElectronicStore.BackEnd.Repository;

interface IInvoiceRepository
{
    Task GetAllInvoices();
    Task GetInvoice();
    Task AddInvoice();
    Task RemoveInvoice();
    Task UpdateInvoice();

}
public class InvoiceRepository
{

}