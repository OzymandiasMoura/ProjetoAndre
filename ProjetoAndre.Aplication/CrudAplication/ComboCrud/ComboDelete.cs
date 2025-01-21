using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using ProjetoAndre.Domain.Services.Common;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.CrudAplication.ComboCrud;

public class ComboDelete
{
    public bool DeleteCombo(Combo combo)
    {
        try
        {
            AppDBContext context = new AppDBContext();
            IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
            routes.Delete(combo, context);

            return true;
        }
        catch
        {
            Log.Error("Conexão com a database falhou.");
            throw new DataConnectionFailureException("Conexão com a database falhou.");
        }
        
    }
}
