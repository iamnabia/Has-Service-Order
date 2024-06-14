using System.ComponentModel.DataAnnotations;

namespace OsDsII.api.Dtos.Customers
{
    public record CreateCustomerDto(string Name, string Email, string Phone);


    //NÃO TENHO CERTEZA MAS ACHO QUE NÃO É AQUI, COLAR EM OUTRO LUGAR DEPOIS
    /*public record CreateCustomerDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }

        public CreateCustomerDto(string email, string name, string phone)
        {
            Email = email;
            Name = name;
            Phone = phone;
        }
    }*/
}
