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

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    //Get
    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _mapper.Map<List<CategoryDto>>(_categoryService.GetAll());

        var result = new ResultModel<CategoryDto>();
        if (data.Count > 0)
        {
            result = new ResultModel<CategoryDto>()
            {
                DataList = data,
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<CategoryDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        var data = _mapper.Map<CategoryDto>(_categoryService.GetById(id));

        var result = new ResultModel<CategoryDto>();
        if (data != null)
        {
            result = new ResultModel<CategoryDto>()
            {
                Data = data,
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<CategoryDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }
    }

    //Create
    [HttpPost]
    public IActionResult Create(CategoryDto categoryDto)
    {
        var data = _mapper.Map<Category>(categoryDto);
        _categoryService.Add(data);

        var result = new ResultModel<CategoryDto>();
        if (data.Id > 0)
        {
            result = new ResultModel<CategoryDto>()
            {

                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.Created
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<CategoryDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }
    }

    //Update
    [HttpPost("update")]
    public IActionResult Update(CategoryDto categoryDto)
    {
        var result = new ResultModel<CategoryDto>();

        if (categoryDto.Id > 0)
        {
            var address = _mapper.Map<Category>(categoryDto);
            _categoryService.Update(address);
            result = new ResultModel<CategoryDto>()
            {
                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        result = new ResultModel<CategoryDto>()
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
        var data = _categoryService.GetById(id);
        if (data != null)
        {
            data.Status = false;
            _categoryService.Update(data);
        }

        var result = new ResultModel<CategoryDto>();
        if (data.Id > 0)
        {
            result = new ResultModel<CategoryDto>()
            {

                Message = ConstantMessage.SuccessListMessage,
                StatusCode = (int)HttpStatusCode.OK
            };
            return Ok(result);
        }
        else
        {
            result = new ResultModel<CategoryDto>()
            {
                Message = ConstantMessage.NoRecordsFound,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            return Ok(result);
        }
    }

}
