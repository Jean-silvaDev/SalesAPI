using Application.DTOs;
using Application.UseCases.Products.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controller}")]
public class ProductsController : ControllerBase
{
    private readonly CreateProductUseCase _createProductUseCase;

    public ProductsController(CreateProductUseCase createProductUseCase)
    {
        _createProductUseCase = createProductUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
    {
        await _createProductUseCase.Execute(dto);
        return Ok();
    }
}
