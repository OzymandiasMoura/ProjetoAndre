using ProjetoAndre.Aplication.Controllers.Common;
using ProjetoAndre.Aplication.CrudAplication.ComboCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ComboControllers;

public class ComboUpdateController
{
    private readonly ComboUpdate _comboUpdate;
    private ComboRequest _comboRequest;

    public ComboUpdateController(ComboRequest comboRequest)
    {
        _comboRequest = comboRequest;
        _comboUpdate = new ComboUpdate();
    }

    public void UpdateComboController()
    {
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(_comboRequest);

        if (_comboRequest.Products != null)
        {
            var list = _comboRequest.Products;
            var list2 = ControllerTools<Product, ProductRequest>.RequestToEntityList(list);
            if (combo.ProductsInCombo != list2)
            {
                combo.ProductsInCombo = list2;
            }
        }
        if (combo == null)
        {
            Log.Error("ComboRequest falhou em passar as informações para UpdateController.");
            throw new InvalidComboException("ComboRequest falhou em passar as informações para UpdateController.");
        }
        if (combo.Name != _comboRequest.Name)
        {
            combo.Name = _comboRequest.Name;
        }
        if (combo.Discount != _comboRequest.Discount)
        {
            combo.Discount = _comboRequest.Discount;
        }

        var test = _comboUpdate.UpdateCombo(combo);
        if (test == false)
        {
            Log.Error("Falha em passar informações para ComboUpdate.");
            throw new InvalidComboException("Falha em passar informações para ComboUpdate.");
        }
    }
}
