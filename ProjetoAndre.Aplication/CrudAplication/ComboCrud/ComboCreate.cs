using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;
using ProjetoAndre.Domain.Services.Common;

namespace ProjetoAndre.Aplication.CrudAplication.ComboCrud;

public class ComboCreate
{
    public void Create(Combo combo)
    {
        AppDBContext context = new AppDBContext();
        IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
        routes.Create(combo, context);
    }
}
