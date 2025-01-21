using ProjetoAndre.Aplication.Controllers.Common;
using ProjetoAndre.Aplication.CrudAplication.ProductCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ProductControllers;

public class ProductDeleteController
{
    private readonly ProductDelete _productDelete;
    private ProductRequest _productRequest;

    public ProductDeleteController(ProductRequest request)
    {
        _productDelete = new ProductDelete();
        _productRequest = request;
    }


    public void DeleteProductController()
    {
        Product? product = ControllerTools<Product, ProductRequest>.RequestToEntity(_productRequest);
        if (product == null)
        {
            Log.Error("ProductRequest falhou em passar as informações para o DeleteController.");
            throw new InvalidProductRequestException("ProductRequest falhou em passar as informações para o DeleteController.");
        }
        var test = _productDelete.DeleteProduct(product);
        if (test == false)
        {
            Log.Error("O produto em DeleteController falhou ao se conectar com ProductDelete.");
            throw new InvalidProductRequestException("O produto em DeleteController falhou ao se conectar com ProductDelete.");
        }
    }
}
