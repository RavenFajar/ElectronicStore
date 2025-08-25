using Microsoft.EntityFrameworkCore;
using ElectronicStore.BackEnd.Models;
using ElectronicStore.BackEnd.Entities;
using System.Reflection.Metadata.Ecma335;

namespace ElectronicStore.BackEnd.Repository;

interface IItemsRepository
{
    Task<List<Items>> GetAllItems();
    Task<Items> GetItemById(Guid id);
    Task<Items> AddItem(Items item);
    Task<bool> DeleteItem(Guid id);
    Task<Items?> UpdateItemAsync(Items updatedItem);
}
public class ItemsRepository : IItemsRepository
{
    private readonly ApplicationtDbContext _db;

    public ItemsRepository(ApplicationtDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<List<Items>> GetAllItems()
    {
        return await _db.Items.Where(x => !x.IsDelete).ToListAsync();
    }
    public async Task<Items> GetItemById(Guid id)
    {
        var result = await _db.Items.Where(x => !x.IsDelete && x.Id == id).FirstOrDefaultAsync();
        if (result == null) return null!;
        return result;
    }
    public async Task<Items> AddItem(Items item)
    {
        var entry = await _db.Items.AddAsync(item);
        await _db.SaveChangesAsync();
        return entry.Entity;
    }
    public async Task<bool> DeleteItem(Guid id)
    {
        var item = await _db.Items.FindAsync(id);
        if (item is null) return false!;
        item.IsDelete = true;
        _db.SaveChanges();
        return true;

    }
    public async Task<Items?> UpdateItemAsync(Items updatedItem)
    {
        var existing = await _db.Items.FindAsync(updatedItem.Id);
        if (existing is null) return null;

        existing.ItemTypes = updatedItem.ItemTypes;
        existing.ItemCode = updatedItem.ItemCode;
        existing.Name = updatedItem.Name;
        existing.Length = updatedItem.Length;
        existing.Width = updatedItem.Width;
        existing.Height = updatedItem.Height;
        existing.Price = updatedItem.Price;
        existing.IsDiscount = updatedItem.IsDiscount;
        existing.Discount = updatedItem.Discount;
        existing.Description = updatedItem.Description;
        existing.Picture = updatedItem.Picture;

        await _db.SaveChangesAsync();
        return existing;
    }

}
