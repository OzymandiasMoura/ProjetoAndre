using ProjetoAndre.Aplication.CrudAplication.Combos;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;

namespace ProjetoAndre.Aplication.Controllers;

public class ComboController
{   
    public void CreateController(ComboRequest request)
    {
        ComboCrudAplication comboCrudAplication = new ComboCrudAplication();
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(request);
        if (combo == null)
        {
            throw new Exception("Combo é nulo");
        }
        comboCrudAplication.Create(combo);
    }
    public List<ComboRequest> ReadController()
    {
        ComboCrudAplication comboCrudAplication = new ComboCrudAplication();
        List<Combo> combos = comboCrudAplication.ReadCombos();
        List<ComboRequest> requests = ControllerTools<Combo, ComboRequest>.EntityToRequestList(combos);
        return requests;
    }
    public void UpdateController(ComboRequest request)
    {
        ComboCrudAplication comboCrudAplication = new ComboCrudAplication();
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(request);        
        //Update foi realizado no método RequestToEntity()
        if (combo == null)
        {
            throw new Exception("Combo é nulo");
        }        
    }
    public void DeleteController(ComboRequest request)
    {
        ComboCrudAplication comboCrudAplication = new ComboCrudAplication();
        Combo? combo =  ControllerTools<Combo, ComboRequest>.RequestToEntity(request);
        if (combo == null)
        {
            throw new Exception("Combo é nulo");
        }
        comboCrudAplication.Delete(combo);
    }

    public void AddProductToComboController(List<ProductRequest> productRequests, ComboRequest comboRequest)
    {
        Combo? combo =  ControllerTools<Combo, ComboRequest>.RequestToEntity(comboRequest);
        if (combo == null)
        {
            throw new Exception("Combo é nulo");
        }
        List<Product> productsList = ControllerTools<Product, ProductRequest>.RequestToEntityList(productRequests);
        ProductServiceManager productServiceManager = new ProductServiceManager();
        productServiceManager.AddProductToCombo(productsList, combo);
    }

    public void RemoveProductFromComboController(List<ProductRequest> productRequests, ComboRequest comboRequest)
    {
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(comboRequest);
        if (combo == null)
        {
            throw new Exception("Combo é nulo");
        }
        List<Product> productsList = ControllerTools<Product, ProductRequest>.RequestToEntityList(productRequests);
        ProductServiceManager productServiceManager = new ProductServiceManager();
        productServiceManager.RemoveProductFromCombo(productsList, combo);
    }

   
}
