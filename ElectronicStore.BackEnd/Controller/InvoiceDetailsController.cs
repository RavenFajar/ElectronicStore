
// using System.ComponentModel;
// using System.ComponentModel.DataAnnotations;

// using global::ElectronicStore.BackEnd.Entities;
// using global::ElectronicStore.BackEnd.Models.Dto;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;

// namespace ElectronicStore.BackEnd.Controllers;

// [Route("api/[controller]")]
// [ApiController]
// public class InvoiceDetailController : ControllerBase
// {
//     private readonly ApplicationtDbContext dBContext;

//     public InvoiceDetailController(ApplicationtDbContext dBContext)
//     {
//         this.dBContext = dBContext;
//     }
//     [HttpGet]
//     public IActionResult GetAllInvoiceDetails()
//     {
//         var allInvoiceDetails = dBContext.Items.ToList();
//         return Ok(allInvoiceDetails);
//     }
//     [HttpPost]
//     public IActionResult AddInvoiceDetail(AddInvoiceDetailsDto addInvoiceDetailDto, AddItemDto addItemDto)
//     {

//         var addInvoiceDetails = new InvoiceDetails()
//         {
//             Invoice = new Invoice(),
//             Item = new Items()
//             {
//                 ItemCode = addItemDto.ItemCode,
//                 Name = addItemDto.Name,
//                 Length = addItemDto.Length,
//                 Width = addItemDto.Width,
//                 Height = addItemDto.Height,
//                 Price = addItemDto.Price,
//                 Description = addItemDto.Description,
//                 Picture = addItemDto.Picture
//             },
//             Quantity = addInvoiceDetailDto.Quantity,
//             UnitPrice = addInvoiceDetailDto.UnitPrice,
//             Discount = addInvoiceDetailDto.Discount,
//             Items = new List<Items>(),

//         };

//         dBContext.InvoiceDetails.Add(addInvoiceDetails);
//         dBContext.SaveChanges();
//         return Ok(addInvoiceDetails);
//     }

//     [HttpGet]
//     [Route("{id:Guid}")]
//     public IActionResult GetItemById(Guid id)
//     {
//         var item = dBContext.Items.Find(id);

//         if (item is null)
//         {
//             return NotFound();
//         }
//         return Ok(item);

//     }
//     [HttpPut]
//     [Route("{id:Guid}")]
//     public IActionResult UpdateItem(Guid id, UpdateItemDto updateItemDto)
//     {

//         var item = dBContext.Items.Find(id);
//         if (item is null)
//         {
//             return NotFound();
//         }
//         item.ItemCode = updateItemDto.ItemCode;
//         item.Name = updateItemDto.Name;
//         item.Length = updateItemDto.Length;
//         item.Width = updateItemDto.Width;
//         item.Height = updateItemDto.Height;
//         item.Price = updateItemDto.Price;
//         item.Description = updateItemDto.Description;
//         item.Picture = updateItemDto.Picture;

//         dBContext.SaveChanges();
//         return Ok(item);
//     }
//     [HttpDelete]
//     [Route("{id:Guid}")]
//     public IActionResult DeleteItem(Guid id)
//     {
//         var item = dBContext.Items.Find(id);
//         if (item is null)
//         {
//             return NotFound();
//         }
//         dBContext.Items.Remove(item);
//         dBContext.SaveChanges();
//         return Ok(item);
//     }
// }
