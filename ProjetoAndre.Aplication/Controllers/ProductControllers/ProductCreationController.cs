using ProjetoAndre.Aplication.Controllers.Common;
using ProjetoAndre.Aplication.CrudAplication.ProductCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ProductControllers;

public class ProductCreationController
{
    private readonly ProductCreate _productCreate;
    private ProductRequest _productRequest;

    public ProductCreationController(ProductRequest request)
    {
        _productCreate = new ProductCreate();
        _productRequest = request;
    }


    public void CreateProductController()
    {
        Product? product = ControllerTools<Product, ProductRequest>.RequestToEntity(_productRequest);
        if (product == null)
        {
            Log.Error("ProductRequest falhou em passar as informações para o CreateController.");
            throw new InvalidProductRequestException("ProductRequest falhou em passar as informações para o CreateController.");
        }
        var test = _productCreate.CreateProduct(product);
        if (test == false)
        {
            Log.Error("O produto em ProductCreationController falhou ao se conectar com ProductCreate.");
            throw new InvalidProductRequestException("O produto em ProductCreationController falhou ao se conectar com ProductCreate.");
        }
    }
}

