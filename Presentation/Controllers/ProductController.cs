using Application.UseCases.Products.CreateProduct;
using Application.UseCases.Products.DeleteCustomer;
using Application.UseCases.Products.GetAllProducts;
using Application.UseCases.Products.GetProductById;
using Application.UseCases.Products.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly CreateProductUseCase _createProductUseCase;
    private readonly GetAllProductsUseCase _getAllProductsUseCase;
    private readonly GetProductByIdUseCase _getProductByIdUseCase;
    private readonly UpdateProductUseCase _updateProductUseCase;
    private readonly DeleteProductUseCase _deleteProductUseCase;

    public ProductController(
        CreateProductUseCase createProductUseCase,
        GetAllProductsUseCase getAllProductsUseCase,
        GetProductByIdUseCase getProductByIdUseCase,
        UpdateProductUseCase updateProductUseCase,
        DeleteProductUseCase deleteProductUseCase)
    {
        _createProductUseCase = createProductUseCase;
        _getAllProductsUseCase = getAllProductsUseCase;
        _getProductByIdUseCase = getProductByIdUseCase;
        _updateProductUseCase = updateProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _createProductUseCase.ExecuteAsync(command, cancellationToken);
        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var products = await _getAllProductsUseCase.ExecuteAsync(cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var product = await _getProductByIdUseCase
            .ExecuteAsync(id, cancellationToken);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _updateProductUseCase.ExecuteAsync(id, command, cancellationToken);
        if (product is null)
            return NotFound();
        return Ok(product);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _deleteProductUseCase.ExecuteAsync(id, cancellationToken);

        return NoContent();
    }
}
