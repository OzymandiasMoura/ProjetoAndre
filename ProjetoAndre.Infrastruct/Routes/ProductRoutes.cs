using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Domain.Services.Common;

namespace ProjetoAndre.Infrastruct.Routes;

public class ProductRoutes : IRoutes<Product, AppDBContext>
{
    public async Task Create(Product entity,  AppDBContext context)
    {
        if (context is null)
        {
            throw new InvalidOperationException("Falha na conexão com o banco de dados.");
        }
        context.products.Add(entity);
        await context.SaveChangesAsync();   
    }

    public List<Product> Read(AppDBContext context)
    {
        if (context is null)
        {
            throw new InvalidOperationException("Falha na conexão com o banco de dados.");
        }
        return context.products.ToList();
    }

    public async Task Update(Product entity, AppDBContext context)
    {
        var existingEntity = await context.combos.FindAsync(entity.IdProduct);
        if (existingEntity == null)
        {
            throw new InvalidOperationException("Produto não encontrado.");
        }        
        if (context is null)
        {
            throw new InvalidOperationException("Falha na conexão com o banco de dados.");
        }
        context.Entry(existingEntity).CurrentValues.SetValues(entity);        
        await context.SaveChangesAsync();
    }
    public async Task Delete(Product entity, AppDBContext context)
    {
        var existingEntity = await context.combos.FindAsync(entity.IdProduct);
        if (existingEntity == null)
        {
            Console.WriteLine("Produto não encontrado");
            return;
        }
        if (context is null)
        {
            throw new InvalidOperationException("Falha na conexão com o banco de dados.");
        }
        context.combos.Remove(existingEntity);
        await context.SaveChangesAsync();
    }
}
