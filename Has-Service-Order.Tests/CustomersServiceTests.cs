using AutoMapper;
using Moq;
using OsDsII.api.Repository.CustomersRepository;
using OsDsII.api.Services.Customers;

namespace CalculadoraSalario.Tests
{
    public class CustomersServiceTests
    {
        private readonly Mock<ICustomersRepository> _mockCustomersRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CustomersService _service;

        public CustomersServiceTests()
        {
            _mockCustomersRepository = new Mock<ICustomersRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CustomersService(_mockCustomersRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async void Should_Return_A_List_Of_Customers()
        {

            _mockCustomersRepository.Setup(repository => repository.GetAllAsync()).ReturnsAsync(/*sua lista de CustomersDto*/);
            var result = await _service.GetAllAsync();
            Assert.Equal(/*sua lista de customers*/, result);
        }
    }
}
