using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Domain.Services.Common;
using ProjetoAndre.Infrastruct.Context;
using Serilog;

namespace ProjetoAndre.Infrastruct.Routes;

public class ComboRoutes : IRoutes<Combo, AppDBContext>
{
    public async Task Create(Combo entity, AppDBContext context)
    {
        if (context is null)
        {
            Log.Error("Falha na conexão com o banco de dados.");
            throw new DataConnectionFailureException("Falha na conexão com o banco de dados.");
        }
        context.combos.Add(entity);
        await context.SaveChangesAsync();
    }

    public List<Combo> Read(AppDBContext context)
    {
        if (context is null)
        {
            Log.Error("Falha na conexão com o banco de dados.");
            throw new DataConnectionFailureException("Falha na conexão com o banco de dados.");
        }
        var list = context.combos;
        return list.ToList();
    }

    public async Task Update(Combo entity, AppDBContext context)
    {
        var existingEntity = await context.combos.FindAsync(entity.IdCombo);
        if (context is null)
        {
            Log.Error("Falha na conexão com o banco de dados.");
            throw new DataConnectionFailureException("Falha na conexão com o banco de dados.");
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
        var existingEntity = await context.combos.FindAsync(entity.IdCombo);
        if (context is null)
        {
            Log.Error("Falha na conexão com o banco de dados.");
            throw new DataConnectionFailureException("Falha na conexão com o banco de dados.");
        }
        if (existingEntity == null)
        {
            Log.Error("Falha na conexão com o banco de dados.");
            throw new DataConnectionFailureException("Falha na conexão com o banco de dados.");
        }        
        context.combos.Remove(existingEntity);
        await context.SaveChangesAsync();
    }
}
