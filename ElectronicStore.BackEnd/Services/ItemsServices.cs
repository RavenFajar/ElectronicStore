using ElectronicStore.BackEnd.Entities;
using ElectronicStore.BackEnd.Models.Dto;
using ElectronicStore.BackEnd.Repository;
using SQLitePCL;

namespace ElectronicStore.BackEnd.Services;

public interface IItemsServices
{
    Task<IEnumerable<Items>> GetItemsAsync();
    Task<Items> GetItemByIdAsync(Guid id);
    Task<Items> AddItemAsync(CreateItemRequest addItem);
    Task<bool> DeleteItemAsync(Guid id);
    Task<Items> UpdateItemAsync(UpdateItemDto updateItem);
}
public class ItemsServices : IItemsServices
{
    private ItemsRepository _itemRepository;
    public ItemsServices(ItemsRepository itemsRepository)
    {
        _itemRepository = itemsRepository;
    }
    public async Task<IEnumerable<Items>> GetItemsAsync()
    {
        var itemsResult = await _itemRepository.GetAllItemsAsync();
        if (itemsResult is not null)
        {
            return itemsResult;
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
    public async Task<Items> GetItemByIdAsync(Guid id)
    {
        var itemResult = await _itemRepository.GetItemByIdAsync(id);
        if (itemResult is not null)
        {
            return itemResult;
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
    public async Task<Items> AddItemAsync(CreateItemRequest itemRequest)
    {
        var addItem = new Items
        {
            Id = new Guid(),
            ItemTypes = itemRequest.ItemTypes,
            ItemCode = itemRequest.ItemCode,
            Name = itemRequest.Name,
            Length = itemRequest.Length,
            Width = itemRequest.Width,
            Height = itemRequest.Height,
            Price = itemRequest.Price,
            IsDiscount = false,
            Discount = 0,
            Description = itemRequest.Description,
            Picture = itemRequest.Picture,
            IsDelete = false
        };

        var result = await _itemRepository.AddItemAsync(addItem);
        if (result is not null)
        {
            return result;
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
    public async Task<bool> DeleteItemAsync(Guid id)
    {
        var deletedItem = await _itemRepository.DeleteItemAsync(id);
        if (deletedItem is false)
        {
            throw new ArgumentException("Failed to Delete Item");
        }
        else
        {
            return true;
        }
    }
    public async Task<Items> UpdateItemAsync(UpdateItemDto updateItem)
    {
        var itemUpdated = new Items
        {
            Id = updateItem.Id,
            ItemTypes = updateItem.ItemTypes,
            ItemCode = updateItem.ItemCode,
            Name = updateItem.Name,
            Length = updateItem.Length,
            Width = updateItem.Width,
            Height = updateItem.Height,
            Price = updateItem.Price,
            IsDiscount = updateItem.IsDiscount,
            Discount = updateItem.Discount,
            Description = updateItem.Description,
            Picture = updateItem.Picture
        };

        var result = await _itemRepository.UpdateItemAsync(itemUpdated);
        if (result is not null)
        {
            return result;
        }
        else
        {
            throw new ArgumentException("Failed To Update The Item");
        }
    }
}