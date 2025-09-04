using ElectronicStore.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.BackEnd.Repository;

public interface IInvoiceDetails
{
    Task<List<Entities.InvoiceDetails>> GetAllInvoiceDetailsAsync();
    Task<InvoiceDetails> GetInvoiceDetailByIdAsync(Guid id);
    Task<InvoiceDetails> AddInvoiceDetailAsync(InvoiceDetails invoiceDetail);
    Task<bool> RemoveInvoiceDetailAsync(Guid id);
    Task<InvoiceDetails> UpdateInvoiceDetailAsync(InvoiceDetails invoiceDetails);
}
public class InvoiceDetailsRepository : IInvoiceDetails
{
    private readonly ApplicationtDbContext _db;

    public InvoiceDetailsRepository(ApplicationtDbContext db)
    {
        _db = db;
    }
    public async Task<List<InvoiceDetails>> GetAllInvoiceDetailsAsync()
    {
        var invoiceDetails = await _db.InvoiceDetails.Where(x => !x.IsDelete).ToListAsync();
        return invoiceDetails.ToList();
    }
    public async Task<InvoiceDetails> GetInvoiceDetailByIdAsync(Guid id)
    {
        var invoiceDetail = await _db.InvoiceDetails.Where(x => !x.IsDelete).FirstOrDefaultAsync(x => x.InvoiceId == id);
        if (invoiceDetail is not null)
        {
            return invoiceDetail;
        }
        throw new ArgumentNullException();
    }
    public async Task<InvoiceDetails> AddInvoiceDetailAsync(InvoiceDetails invoiceDetails)
    {
        var entry = await _db.InvoiceDetails.AddAsync(invoiceDetails);
        await _db.SaveChangesAsync();
        return entry.Entity;
    }
    public async Task<bool> RemoveInvoiceDetailAsync(Guid id)
    {
        var invoiceDetail = await _db.InvoiceDetails.FindAsync(id);
        if (invoiceDetail is null) return false;
        invoiceDetail.IsDelete = true;
        _db.SaveChanges();
        return true;
    }
    public async Task<InvoiceDetails> UpdateInvoiceDetailAsync(InvoiceDetails invoiceDetails)
    {
         var existing = await _db.InvoiceDetails.FindAsync(invoiceDetails.Id);
        if (existing is null)
        {
            throw new ArgumentNullException();
        }
        existing.Quantity = invoiceDetails.Quantity;
        existing.Price = invoiceDetails.Price;

        await _db.SaveChangesAsync();
        return existing;
    }
}