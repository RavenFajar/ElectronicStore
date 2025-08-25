namespace ElectronicStore.BackEnd.Repository;

public interface IItems
{
    Task GetAllItems();
    Task GetItem();
    Task AddItem();
    Task RemoveItem();
    Task UpdateItem();
}

public class Items
{
}
