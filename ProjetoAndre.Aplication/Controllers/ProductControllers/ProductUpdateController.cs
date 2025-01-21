using ProjetoAndre.Aplication.Controllers.Common;
using ProjetoAndre.Aplication.CrudAplication.ProductCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ProductControllers;

public class ProductUpdateController
{
    private readonly ProductUpdate _productUpdate;
    private ProductRequest _productRequest;

    public ProductUpdateController(ProductRequest request)
    {
        _productUpdate = new ProductUpdate();
        _productRequest = request;
    }


    public void UpdateProductController()
    {
        Product? product = ControllerTools<Product, ProductRequest>.RequestToEntity(_productRequest);
        if (product == null)
        {
            Log.Error("ProductRequest falhou em passar as informações para o UpdateController.");
            throw new InvalidProductRequestException("ProductRequest falhou em passar as informações para o UpdateController.");
        }
        if (product.BarCode != _productRequest.BarCode)
        {
            product.BarCode = _productRequest.BarCode;
        }
        if (product.Marca != _productRequest.Marca)
        {
            product.Marca = _productRequest.Marca;
        }
        if (product.SellPrice != _productRequest.SellPrice)
        {
            product.SellPrice = _productRequest.SellPrice;
        }
        if (product.CostPrice != _productRequest.CostPrice)
        {
            product.CostPrice = _productRequest.CostPrice;
        }
        if (product.Name != _productRequest.Name)
        {
            product.Name = _productRequest.Name;
        }
        if (product.Supplier != _productRequest.Supplier)
        {
            product.Supplier = _productRequest.Supplier;
        }
        if (product.NCM != _productRequest.NCM)
        {
            product.NCM = _productRequest.NCM;
        }
        if (product.CFop != _productRequest.CFop)
        {
            product.CFop = _productRequest.CFop;
        }

        var test = _productUpdate.UpdateProduct(product);
        if (test == false)
        {
            Log.Error("O produto em ProductupdateController falhou ao se conectar com ProductUpdate.");
            throw new InvalidProductRequestException("O produto em ProductUpdateController falhou ao se conectar com ProductUpdate.");
        }
    }
}
