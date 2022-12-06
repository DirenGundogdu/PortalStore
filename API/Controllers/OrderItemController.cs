using API.Constants;
using API.Models;
using AutoMapper;
using Core.Entities;
using Core.IServices;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IMapper mapper, IOrderItemService orderItemService)
        {
            _mapper = mapper;
            _orderItemService = orderItemService;
        }

        //Get
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _mapper.Map<List<OrderItemDto>>(_orderItemService.GetAll());

            var result = new ResultModel<OrderItemDto>();
            if (data.Count > 0)
            {
                result = new ResultModel<OrderItemDto>()
                {
                    DataList = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderItemDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _mapper.Map<OrderItemDto>(_orderItemService.GetById(id));
            var result = new ResultModel<OrderItemDto>();
            if (data != null)
            {
                result = new ResultModel<OrderItemDto>()
                {
                    Data = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderItemDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        //Create
        [HttpPost]
        public IActionResult Create(OrderItemDto orderItemDto)
        {
            var data = _mapper.Map<OrderItem>(orderItemDto);
            _orderItemService.Add(data);

            var result = new ResultModel<OrderItemDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<OrderItemDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.Created
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderItemDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        //Update
        [HttpPost("update")]
        public IActionResult Update(OrderItemDto orderItemDto)
        {
            var result = new ResultModel<OrderItemDto>();

            if (orderItemDto.Id > 0)
            {
                var orderItem = _mapper.Map<OrderItem>(orderItemDto);
                _orderItemService.Update(orderItem);
                result = new ResultModel<OrderItemDto>()
                {
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            result = new ResultModel<OrderItemDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }

        //Delete
        [HttpPost("{id}")]
        public IActionResult Remove(int id)
        {
            var data = _orderItemService.GetById(id);
            if (data != null)
            {
                data.Status = false;
                _orderItemService.Update(data);
            }
            var result = new ResultModel<OrderItemDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<OrderItemDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderItemDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }

        }
    }
}
