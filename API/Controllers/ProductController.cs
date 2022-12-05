using API.Constants;
using API.Models;
using AutoMapper;
using DTO;
using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }


    //Get
    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _mapper.Map<List<ProductDto>>(_productService.GetAll());

        var result = new ResultModel<ProductDto>();
        if (data.Count > 0)
        {
            result = new ResultModel<ProductDto>()
            {
                DataList = data,
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<ProductDto>()
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
        var data = _mapper.Map<ProductDto>(_productService.GetById(id));

        var result = new ResultModel<ProductDto>();
        if (data != null)
        {
            result = new ResultModel<ProductDto>()
            {
                Data = data,
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<ProductDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }
    }

    //Create
    [HttpPost]
    public IActionResult Create(ProductProcessDto productProcessDto)
    {
        var data = _mapper.Map<Product>(productProcessDto);
        _productService.Add(data);

        var result = new ResultModel<ProductProcessDto>();
        if (data.Id > 0)
        {
            result = new ResultModel<ProductProcessDto>()
            {

                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.Created
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<ProductProcessDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }




    }

    //Update
    [HttpPost("update")]
    public IActionResult Update(ProductProcessDto productProcessDto)
    {
        var product = _productService.GetById(productProcessDto.Id);


        if (product != null)
        {
            product.OldPrice = product.Price == productProcessDto.Price ? 0 : product.Price;
            product.Price = productProcessDto.Price;
            product.CategoryId = productProcessDto.CategoryId;
            product.Description = productProcessDto.Description;
            product.Name = productProcessDto.Name;
            _productService.Update(product);
           
        }

        var result = new ResultModel<ProductProcessDto>();
        if (product.Id > 0)
        {
            result = new ResultModel<ProductProcessDto>()
            {

                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<ProductProcessDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }



    }

    //Delete
    [HttpPost("{id}")]
    public IActionResult Remove(int id)
    {
        var data = _productService.GetById(id);
        if (data != null)
        {
            data.Status = false;
            _productService.Update(data);
        }
        var result = new ResultModel<ProductProcessDto>();
        if (data.Id > 0)
        {
            result = new ResultModel<ProductProcessDto>()
            {

                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<ProductProcessDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }
    }



}
