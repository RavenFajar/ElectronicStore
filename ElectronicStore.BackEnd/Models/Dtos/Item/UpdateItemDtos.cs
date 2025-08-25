namespace ElectronicStore.BackEnd.Models.Dto;

public record ItemDto(
    Guid Id,
    string ItemCode,
    string Name,
    double Length,
    double Width,
    double Height,
    long Price,
    bool IsDiscount,
    double Discount,
    string Description,
    string Picture,
    string ItemTypeName 
);