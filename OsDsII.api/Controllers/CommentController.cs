using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Dtos;
using OsDsII.api.Dtos.ServiceOrders;
using OsDsII.api.Models;
using OsDsII.api.Repository.CommentsRepository;
using OsDsII.api.Repository.ServiceOrderRepository;
using OsDsII.api.Services.Comments;
using OsDsII.api.Services.ServiceOrders;

namespace OsDsII.api.Controllers
{

    [ApiController]
    [Route("ServiceOrders/{id}/comment")]
    public class CommentController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly IServiceOrderRepository _serviceOrderRepository; // IOC (INVERSION OF CONTROL)
        private readonly ICommentsRepository _commentsRepository;

        private ICommentsService _commentsService;
        private IServiceOrdersService _serviceOrderService;


        public CommentController(IServiceOrderRepository serviceOrderRepository, ICommentsRepository commentsRepository, IServiceOrdersService serviceOrdersService, ICommentsService commentsService)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _commentsRepository = commentsRepository;
            _commentsService = commentsService;
            _serviceOrderService = serviceOrdersService;
        }


        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync(int serviceOrderId)
        {
            try
            {
                ServiceOrder serviceOrderWithComments = await _serviceOrderRepository.GetServiceOrderWithComments(serviceOrderId);
                return Ok(serviceOrderWithComments);

            }

            catch (BaseException ex) 
            {
                return ex.GetResponse();
            }
            
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(int serviceOrderId, CommentDto comment)
        {
            try
            {
                ServiceOrderDto os = await _serviceOrderService.GetServiceOrderFromUserAsync(serviceOrderId);
                Comment commentExists = await _commentsService.AddCommentAsync(serviceOrderId, comment);

                return Ok(commentExists);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private Comment HandleCommentObject(int id, string description)
        {
            return new Comment
            {
                Description = description,
                ServiceOrderId = id
            };
        }
    }
}

