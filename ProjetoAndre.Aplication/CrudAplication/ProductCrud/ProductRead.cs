using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using Serilog;
using ProjetoAndre.Domain.Services.Common;

namespace ProjetoAndre.Aplication.CrudAplication.ProductCrud;

public class ProductRead
{
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
}
