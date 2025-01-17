using ProjetoAndre.Aplication.CrudAplication.Products.ProductValidation;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Entities.InterfaceCrud;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using Serilog;

namespace ProjetoAndre.Aplication.CrudAplication.Products;

public class ProductCrudAplication
{
    
    public void DeleteProduct(ProductRequest request)
    {
        try
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.ValidateProductUpdateDelete(request);
            Product product = new Product(request.Name, request.BarCode, request.Marca, request.CostPrice, request.SellPrice, request.Supplier, request.NCM, request.CFop);
            IRoutes<Product, AppDBContext> routes = new ProductRoutes();
            AppDBContext context = new AppDBContext();
            routes.Delete(product, context);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);  
            throw new Errors(ex.Message);
        }
    }

    public void CreateProduct(ProductRequest request)
    {
        try
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.ValidateProduct(request);
            Product product = new Product(request.Name, request.BarCode, request.Marca, request.CostPrice, request.SellPrice, request.Supplier, request.NCM, request.CFop);
            IRoutes<Product, AppDBContext> routes = new ProductRoutes();
            AppDBContext context = new AppDBContext();
            routes.Create(product, context);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            throw new Errors(ex.Message);
        }
    }

    public List<Product> ReadProducts()
    {
        try
        {
            IRoutes<Product, AppDBContext> routes = new ProductRoutes();
            AppDBContext context = new AppDBContext();
            return routes.Read(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            throw new Errors(ex.Message);
        }
    }
    public void UpdateProduct(ProductRequest request)
    {
        try
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.ValidateProductUpdateDelete(request);
            Product product = new Product(request.Name, request.BarCode, request.Marca, request.CostPrice, request.SellPrice, request.Supplier, request.NCM, request.CFop);
            IRoutes<Product, AppDBContext> routes = new ProductRoutes();
            AppDBContext context = new AppDBContext();
            routes.Update(product, context);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            throw new Errors(ex.Message);
        }
    }
}
