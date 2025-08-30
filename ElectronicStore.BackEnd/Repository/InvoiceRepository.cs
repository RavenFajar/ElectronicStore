using ElectronicStore.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.BackEnd.Repository;

interface IInvoiceRepository
{
    Task<List<Invoice>> GetAllInvoicesAsync();
    Task<Invoice> GetInvoiceByIdAsync(Guid id);
    Task<Invoice> AddInvoiceAsync(Invoice invoice);
    Task<Invoice> RemoveInvoiceAsync(Guid id);
    Task<Invoice> UpdateInvoiceAsync(Invoice invoice);

}
public class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationtDbContext _db;
    public InvoiceRepository(ApplicationtDbContext db)
    {
        _db = db;
    }
    public async Task<List<Invoice>> GetAllInvoicesAsync()
    {
        return await _db.Invoices.Where(x => !x.IsDelete).ToListAsync();
    }
    public async Task<Invoice> GetInvoiceByIdAsync(Guid id)
    {
        var result = await _db.Invoices.Where(x => !x.IsDelete).FirstOrDefaultAsync(x => x.Id == id);
        if (result is not null)
        {
            return result;
        }
        throw new ArgumentNullException();
    }
    public async Task<Invoice> AddInvoiceAsync(Invoice invoice)
    {
        var entry = await _db.Invoices.AddAsync(invoice);
        await _db.SaveChangesAsync();
        return entry.Entity;
    }
    public async Task<Invoice> RemoveInvoiceAsync(Guid id)
    {
        var result = await _db.Invoices.Where(x => !x.IsDelete).FirstOrDefaultAsync(x => x.Id == id);
        if (result is not null)
        {
            result.IsDelete = true;
            _db.SaveChanges();
            return result;
        }
        throw new ArgumentNullException();
    }
    public async Task<Invoice> UpdateInvoiceAsync(Invoice invoice)
    {
        var existing = await _db.Invoices.Where(x => !x.IsDelete).FirstOrDefaultAsync(x => x.Id == invoice.Id);
        if (existing is not null)
        {
            existing.InvoiceDate = invoice.InvoiceDate;
            existing.LabourPrice = invoice.LabourPrice;
            existing.GrandPrice = invoice.GrandPrice;
            existing.InvoiceDetails = invoice.InvoiceDetails;

            _db.SaveChanges();
            return existing;
        }
        throw new ArgumentNullException();
    }
}