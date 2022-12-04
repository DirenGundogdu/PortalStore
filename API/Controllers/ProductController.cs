using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
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

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _mapper.Map<List<ProductDto>>(_productService.GetAll());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _mapper.Map<ProductDto>(_productService.GetById(id));
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(ProductDto productDto)
    {
        var result = _mapper.Map<Product>(productDto);
        _productService.Add(result);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Update(ProductDto productDto)
    {
        var product = _productService.GetById(productDto.Id);
        if (product != null)
        {
            product.OldPrice = product.Price == productDto.Price ? 0 : product.Price;
            product.Price = productDto.Price;
            product.CategoryId = productDto.CategoryId;
            product.Description = productDto.Description;
            product.Name = productDto.Name;
            _productService.Update(product);
            return Ok();
        }
        return NoContent();
    }



}
