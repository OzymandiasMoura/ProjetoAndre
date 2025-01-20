using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Entities.InterfaceCrud;
using ProjetoAndre.Infrastruct.Context;
using ProjetoAndre.Infrastruct.Routes;

namespace ProjetoAndre.Aplication.CrudAplication.Combos;

public class ComboCrudAplication
{    
    public void Create(Combo combo)
    {        
        AppDBContext context = new AppDBContext();        
        IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
        routes.Create(combo, context);
    }
    public List<Combo> ReadCombos()
    {
        AppDBContext context = new AppDBContext();
        IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
        return routes.Read(context);
    }
    public async void Update(Combo combo, Combo Other)
    {        
        if (combo.Code != Other.Code)
        {
            throw new Exception("Code do combo não é igual ao Code do Other");
        }       
        if (combo.Name != Other.Name)
        {
            combo.Name = Other.Name;
        }
        if (combo.Discount != Other.Discount)
        {
            combo.Discount = Other.Discount;
        }
        if (combo.ProductsInCombo != Other.ProductsInCombo)
        {
            combo.ProductsInCombo = Other.ProductsInCombo;
        }
        AppDBContext context = new AppDBContext();        
        IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
        await routes.Update(combo, context);
    }
    
    public void Delete(Combo combo)
    {
        AppDBContext context = new AppDBContext();        
        IRoutes<Combo, AppDBContext> routes = new ComboRoutes();
        routes.Delete(combo, context);
    }
}
