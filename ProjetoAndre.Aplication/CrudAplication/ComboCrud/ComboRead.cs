using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using ProjetoAndre.Domain.Services.Common;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.CrudAplication.ComboCrud;

public class ComboRead
{
    public List<Combo> ReadCombo()
    {
        try
        {
            AppDBContext context = new AppDBContext();
            IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
            return routes.Read(context);
        }
        catch(Exception ex)
        {
            Log.Error("Conexão com a database falhou.");
            throw new DataConnectionFailureException("Conexão com a database falhou.");
        }
        
    }
}
