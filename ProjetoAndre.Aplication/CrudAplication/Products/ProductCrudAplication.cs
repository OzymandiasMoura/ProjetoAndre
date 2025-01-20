using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Entities.InterfaceCrud;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using Serilog;

namespace ProjetoAndre.Aplication.CrudAplication.Products;

public class ProductCrudAplication
{
    
    public void DeleteProduct(Product product)
    {
        try
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.ValidateProductUpdateDelete(product);            
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

    public void CreateProduct(Product product)
    {
        try
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.ValidateProduct(product);            
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
    public void UpdateProduct(Product product, Product other)
    {
        try
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.ValidateProductUpdateDelete(product);
            productCrudAplication.ValidateProductUpdateDelete(other);
            if (product.BarCode != other.BarCode)
            {
                throw new Exception("BarCode do produto não é igual ao BarCode do Other");
            }            
            if (product.Name != other.Name)
            {
                product.Name = other.Name;
            }
            if (product.Marca != other.Marca)
            {
                product.Marca = other.Marca;
            }
            if (product.CostPrice != other.CostPrice)
            {
                product.CostPrice = other.CostPrice;
            }
            if (product.SellPrice != other.SellPrice)
            {
                product.SellPrice = other.SellPrice;
            }
            if (product.Supplier != other.Supplier)
            {
                product.Supplier = other.Supplier;
            }
            if (product.NCM != other.NCM)
            {
                product.NCM = other.NCM;
            }
            if (product.CFop != other.CFop)
            {
                product.CFop = other.CFop;
            }
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
