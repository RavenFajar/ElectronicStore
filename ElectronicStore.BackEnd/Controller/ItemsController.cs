using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ElectronicStore.BackEnd.Entities;
using ElectronicStore.BackEnd.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ApplicationtDbContext dBContext;

    public ItemsController(ApplicationtDbContext dBContext)
    {
        this.dBContext = dBContext;
    }
    [HttpGet]
    public IActionResult GetAllItems()
    {
        var allEmployees = dBContext.Items.ToList();
        return Ok(allEmployees);
    }
    [HttpPost]
    public IActionResult AddItem(CreateItemRequest AddItem)
    {

        var addItem = new Items()
        {
            ItemCode = AddItem.ItemCode,
            Name = AddItem.Name,
            Length = AddItem.Length,
            Width = AddItem.Width,
            Height = AddItem.Height,
            Price = AddItem.Price,
            Description = AddItem.Description,
            Picture = AddItem.Picture
        };

        dBContext.Items.Add(addItem);
        dBContext.SaveChanges();
        return Ok(addItem);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetItemById(Guid id)
    {
        var item = dBContext.Items.Find(id);

        if (item is null)
        {
            return NotFound();
        }
        return Ok(item);

    }
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateItem(Guid id, ItemDto updateItemDto)
    {

        var item = dBContext.Items.Find(id);
        if (item is null)
        {
            return NotFound();
        }
        item.ItemCode = updateItemDto.ItemCode;
        item.Name = updateItemDto.Name;
        item.Length = updateItemDto.Length;
        item.Width = updateItemDto.Width;
        item.Height = updateItemDto.Height;
        item.Price = updateItemDto.Price;
        item.Description = updateItemDto.Description;
        item.Picture = updateItemDto.Picture;

        dBContext.SaveChanges();
        return Ok(item);
    }
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        var item = dBContext.Items.Find(id);
        if (item is null)
        {
            return NotFound();
        }
        dBContext.Items.Remove(item);
        dBContext.SaveChanges();
        return Ok(item);
    }
}
