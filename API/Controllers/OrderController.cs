﻿using API.Constants;
using API.Models;
using AutoMapper;
using Business.Services;
using Core.Entities;
using Core.IServices;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper, IOrderService orderService, IOrderItemService orderItemService, IBasketService basketService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _basketService = basketService;
        }

        //Get
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _mapper.Map<List<OrderDto>>(_orderService.Where(x => x.Status == true));

            var result = new ResultModel<OrderDto>();
            if (data.Count > 0)
            {
                result = new ResultModel<OrderDto>()
                {
                    DataList = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderDto>()
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
            var data = _mapper.Map<OrderDto>(_orderService.GetById(id));
            var result = new ResultModel<OrderDto>();
            if (data != null)
            {
                result = new ResultModel<OrderDto>()
                {
                    Data = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        //Create
        [HttpPost]
        public IActionResult Create(OrderDto orderDto)
        {
            var data = _mapper.Map<Order>(orderDto);
            _orderService.Add(data);

            var result = new ResultModel<OrderDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<OrderDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.Created
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        //Update
        [HttpPost]
        public IActionResult Update(OrderDto orderDto)
        {
            var result = new ResultModel<OrderDto>();

            if (orderDto.Id > 0)
            {
                var order = _mapper.Map<Order>(orderDto);
                _orderService.Update(order);
                result = new ResultModel<OrderDto>()
                {
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            result = new ResultModel<OrderDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }

        //Delete
        [HttpGet("{id}")]
        public IActionResult Remove(int id)
        {
            var data = _orderService.GetById(id);
            if (data != null)
            {
                data.Status = false;
                _orderService.Update(data);
            }
            var result = new ResultModel<OrderDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<OrderDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<OrderDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }

        }

        [HttpPost]
        public IActionResult CreateOrder(BasketProcessDto basketProcess)
        {
            var getCustomerBasket = _basketService.GetCustomerBasket(basketProcess.CustomerId);

            Order order = new Order()
            {
                AddressId = basketProcess.AddressId,
                TotalPrice = basketProcess.TotalPrice,
                CustomerId = basketProcess.CustomerId,
            };
            _orderService.Add(order);
            if (order.Id > 0)
            {
                foreach (var item in getCustomerBasket)
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Product.Price,
                    };
                    _orderItemService.Add(orderItem);
                }
                _basketService.RemoveRange(getCustomerBasket);
            }
            return Ok();
        }
    }
}
