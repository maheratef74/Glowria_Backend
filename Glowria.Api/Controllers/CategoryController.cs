using AutoMapper;
using Glowria.Application.Commands.Category;
using Glowria.Application.Services.ResponseService;
using Glowria.Domain.Entities;
using Glowria.Domain.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Glowria.Api.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IResponseService _responseService;
    
    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, IResponseService responseService)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _responseService = responseService;
    }

    /*[HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] CategoryAddRequest request)
    {
        var category = _mapper.Map<Category>(request);
        await _categoryRepository.AddAsync(category);
       // return Ok();
    }*/
}