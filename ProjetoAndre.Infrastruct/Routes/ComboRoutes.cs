using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Entities.InterfaceCrud;
using ProjetoAndre.Infrastruct.Context;

namespace ProjetoAndre.Infrastruct.Routes;

public class ComboRoutes : IRoutes<Combo, AppDBContext>
{
    public async Task Create(Combo entity, AppDBContext context)
    {
        if (context is null)
        {
            throw new InvalidOperationException("Falha na conexão com o banco de dados.");
        }
        context.combos.Add(entity);
        await context.SaveChangesAsync();
    }

    public List<Combo> Read(AppDBContext context)
    {
        if (context is null)
        {
            throw new InvalidOperationException("Falha na conexão com o banco de dados.");
        }
        var list = context.combos;
        return list.ToList();
    }

    public async Task Update(Combo entity, AppDBContext context)
    {
        var existingEntity = await context.combos.FindAsync(entity.Id);
        if (context is null)
        {
            throw new InvalidOperationException("Falha na conexão com o banco de dados.");
        }
        if (existingEntity == null)
        {
            throw new InvalidOperationException("Produto não encontrado.");
        }
        context.Entry(existingEntity).CurrentValues.SetValues(entity);        
        await context.SaveChangesAsync();
    }
    public async Task Delete(Combo entity, AppDBContext context)
    {
        var existingEntity = await context.combos.FindAsync(entity.Id);
        if (existingEntity == null)
        {
            Console.WriteLine("Combo não encontrado");
            return;
        }        
        context.combos.Remove(existingEntity);
        await context.SaveChangesAsync();
    }
}
