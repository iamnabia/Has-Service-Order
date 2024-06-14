using OsDsII.api.Dtos.ServiceOrders;
using OsDsII.api.Models;
using System.Numerics;

namespace OsDsII.api.Dtos.Customers
{
    public record CustomerDto (string email, string name, string phone, List<ServiceOrderDto> ListServiceOrde);


    //PODE SER UTIL
    /*public record ServiceOrderDto(string Description,
        double Price,
        StatusServiceOrder Status,
        DateTimeOffset OpeningDate,
        DateTimeOffset FinishDate);
    */
}
