using AutoMapper;
using Business.Services;
using DTO;
using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using API.Constants;
using API.Models;
using System.Net;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IMapper _mapper;

    public AddressController(IAddressService addressService, IMapper mapper)
    {
        _addressService = addressService;
        _mapper = mapper;
    }

    //Get
    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _mapper.Map<List<AddressDto>>(_addressService.GetAll());
        var result = new ResultModel<AddressDto>();
        if (data.Count > 0)
        {
            result = new ResultModel<AddressDto>()
            {
                DataList = data,
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<AddressDto>()
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
        var data = _mapper.Map<AddressDto>(_addressService.GetById(id));
        var result = new ResultModel<AddressDto>();
        if (data != null)
        {
            result = new ResultModel<AddressDto>()
            {
                Data = data,
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<AddressDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }
    }

    //Create
    [HttpPost]
    public IActionResult Create(AddressProcessDto addressProcessDto)
    {
        var data = _mapper.Map<Address>(addressProcessDto);
        _addressService.Add(data);

        var result = new ResultModel<AddressProcessDto>();
        if (data.Id > 0)
        {
            result = new ResultModel<AddressProcessDto>()
            {

                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.Created
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<AddressProcessDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }

    }

    //Update
    [HttpPost("update")]
    public IActionResult Update(AddressProcessDto addressProcessDto) 
    {
        var result = new ResultModel<AddressProcessDto>();

        if (addressProcessDto.Id > 0)
        {
            var address = _mapper.Map<Address>(addressProcessDto);
            _addressService.Update(address);
            result = new ResultModel<AddressProcessDto>()
            {
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        result = new ResultModel<AddressProcessDto>()
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
        var data = _addressService.GetById(id);
        if (data != null)
        {
            data.Status = false;
            _addressService.Update(data);
        }
        var result = new ResultModel<AddressProcessDto>();
        if (data.Id > 0)
        {
            result = new ResultModel<AddressProcessDto>()
            {

                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<AddressProcessDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }

    }

}