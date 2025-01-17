using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Domain.Entities.InterfaceCrud;

namespace ProjetoAndre.Infrastruct.Routes;

public class ProductRoutes : IRoutes<Product, AppDBContext>
{
    public async Task Create(Product entities,  AppDBContext context)
    {
        Product product = new Product(entities.Name, entities.BarCode, entities.Marca, entities.CostPrice, entities.SellPrice, entities.Supplier, entities.NCM, entities.CFop);
        context.products.Add(product);
        await context.SaveChangesAsync();   
    }

    public List<Product> Read(AppDBContext context)
    {        
        return context.products.ToList();
    }

    public async Task Update(Product entities, AppDBContext context)
    {        
        context.products.Update(entities);
        await context.SaveChangesAsync();
    }
    public async Task Delete(Product entities, AppDBContext context)
    {
        context.products.Remove(entities);
        await context.SaveChangesAsync();
    }
}
