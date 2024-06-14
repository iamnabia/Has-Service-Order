using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Dtos.ServiceOrders;
using OsDsII.api.Models;
using OsDsII.api.Repository.CustomersRepository;
using OsDsII.api.Repository.ServiceOrderRepository;
using OsDsII.api.Services.ServiceOrders;

namespace OsDsII.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ServiceOrdersController : ControllerBase
    {
        private readonly IServiceOrderRepository _serviceOrderRepository; // IOC (INVERSION OF CONTROL)
        private readonly ICustomersRepository _customersRepository;
        private readonly IServiceOrdersService _serviceOrdersService;

        public ServiceOrdersController(IServiceOrderRepository serviceOrderRepository, ICustomersRepository customersRepository, IServiceOrdersService serviceOrdersService)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _customersRepository = customersRepository;
            _serviceOrdersService = serviceOrdersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServiceOrderAsync()
        {
            try
            {
                List<ServiceOrder> serviceOrders = await _serviceOrderRepository.GetAllAsync();
                return Ok(serviceOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceOrderById(int id)
        {
            try
            {
                ServiceOrder serviceOrder = await _serviceOrderRepository.GetByIdAsync(id);
                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceOrderAsync(CreateServiceOrderDto createServiceOrderDto)
        {
            try
            {
                await _serviceOrdersService.CreateServiceOrderAsync(createServiceOrderDto);
                return Created("CreateServiceOrderAsync", createServiceOrderDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}/status/finish")]
        public async Task<IActionResult> FinishServiceOrderAsync(int id)
        {
            try
            {
                ServiceOrder serviceOrder = await _serviceOrderRepository.GetByIdAsync(id);
                serviceOrder.FinishOS();
                await _serviceOrderRepository.FinishAsync(serviceOrder);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/status/cancel")]
        public async Task<IActionResult> CancelServiceOrder(int id)
        {
            try
            {
                ServiceOrder serviceOrder = await _serviceOrderRepository.GetByIdAsync(id);
                serviceOrder.Cancel();
                await _serviceOrderRepository.CancelAsync(serviceOrder);


                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}