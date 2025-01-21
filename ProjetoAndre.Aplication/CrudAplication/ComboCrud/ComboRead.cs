using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using ProjetoAndre.Domain.Services.Common;

namespace ProjetoAndre.Aplication.CrudAplication.ComboCrud;

public class ComboRead
{
    public List<Combo> ReadCombos()
    {
        AppDBContext context = new AppDBContext();
        IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
        return routes.Read(context);
    }
}
