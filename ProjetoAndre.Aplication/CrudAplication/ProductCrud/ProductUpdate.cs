using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using Serilog;
using ProjetoAndre.Domain.Services.Common;

namespace ProjetoAndre.Aplication.CrudAplication.ProductCrud;

public class ProductUpdate
{
    public bool UpdateProduct(Product product)
    {
        try
        {            
            ProductValidationExtension.ValidateProductUpdateDelete(product);            
            IRoutes<Product, AppDBContext> routes = new ProductRoutes();
            AppDBContext context = new AppDBContext();
            routes.Update(product, context);

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            throw new Errors(ex.Message);
        }
    }
}
