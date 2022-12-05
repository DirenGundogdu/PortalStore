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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        //Get
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _mapper.Map<List<CustomerDto>>(_customerService.GetAll());
            var result = new ResultModel<CustomerDto>();
            if (data.Count > 0)
            {
                result = new ResultModel<CustomerDto>()
                {
                    DataList = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<CustomerDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var data = _mapper.Map<CustomerDto>(_customerService.GetById(id));

            var result = new ResultModel<CustomerDto>();
            if (data != null)
            {
                result = new ResultModel<CustomerDto>()
                {
                    Data = data,
                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<CustomerDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }


        //Create
        [HttpPost]
        public IActionResult Create(CustomerDto customerDto)
        {
            var data = _mapper.Map<Customer>(customerDto);
            _customerService.Add(data);

            var result = new ResultModel<CustomerDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<CustomerDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.Created
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<CustomerDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }

        //Update
        [HttpPost("update")]
        public IActionResult Update(CustomerDto customerDto)
        {
            var result = new ResultModel<CustomerDto>();
            if (customerDto.Id > 0)
            {
                var customer = _mapper.Map<Customer>(customerDto);
                _customerService.Update(customer);
                result = new ResultModel<CustomerDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            result = new ResultModel<CustomerDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }

        //Delete
        [HttpPost("{id}")]
        public IActionResult Remove(int id) {
            var data = _customerService.GetById(id);
            if (data != null)
            {
                data.Status = false;
                _customerService.Update(data);
            }
            var result = new ResultModel<CustomerDto>();
            if (data.Id > 0)
            {
                result = new ResultModel<CustomerDto>()
                {

                    Message = ConstantMessage.SuccessListMessage,
                    StatusCode = (int)HttpStatusCode.OK
                };
                return Ok(result);
            }
            else
            {
                result = new ResultModel<CustomerDto>()
                {
                    Message = ConstantMessage.NoRecordsFound,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return Ok(result);
            }
        }
    }
}
