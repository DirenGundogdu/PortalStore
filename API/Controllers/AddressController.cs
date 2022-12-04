using AutoMapper;
using Business.Services;
using Core.DTOs;
using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
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

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _mapper.Map<List<AddressDto>>(_addressService.GetAll());
        return Ok(result);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _mapper.Map<AddressDto>(_addressService.GetById(id));
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(AddressDto addressDto)
    {
        var result = _mapper.Map<Address>(addressDto);
        _addressService.Add(result);
        return Ok(result);
    }

}