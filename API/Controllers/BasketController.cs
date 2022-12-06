using API.Constants;
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
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IMapper mapper, IBasketService basketService)
        {
            _mapper = mapper;
            _basketService = basketService;
        }

        //Get
        [HttpGet("{customerId}")]
        public IActionResult GetAll(int customerId)
        {
            var data = _mapper.Map<List<BasketDto>>(_basketService.GetCustomerBasket(customerId));

            var result = new ResultModel<BasketDto>();
            if (data.Count > 0)
            {
                result = new ResultModel<BasketDto>()
                {
                    DataList = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<BasketDto>()
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
            var data = _mapper.Map<BasketDto>(_basketService.GetById(id));

            var result = new ResultModel<BasketDto>();
            if (data != null)
            {
                result = new ResultModel<BasketDto>()
                {
                    Data = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<BasketDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        //Create
        [HttpPost]
        public IActionResult Create(BasketProcessDto basketDto)
        {
            var data = _mapper.Map<Basket>(basketDto);
            _basketService.Add(data);

            var result = new ResultModel<BasketProcessDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<BasketProcessDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.Created
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<BasketProcessDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        //Update
        [HttpPost]
        public IActionResult Update(BasketProcessDto BasketDto)
        {
            var result = new ResultModel<BasketProcessDto>();

            if (BasketDto.Id > 0)
            {
                var address = _mapper.Map<Basket>(BasketDto);
                _basketService.Update(address);
                result = new ResultModel<BasketProcessDto>()
                {
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            result = new ResultModel<BasketProcessDto>()
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
            var data = _basketService.GetById(id);
            if (data != null)
            {
                data.Status = false;
                _basketService.Update(data);
            }

            var result = new ResultModel<BasketProcessDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<BasketProcessDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<BasketProcessDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }


    }
}
