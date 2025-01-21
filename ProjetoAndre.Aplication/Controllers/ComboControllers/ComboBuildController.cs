using ProjetoAndre.Aplication.Controllers.Common;
using ProjetoAndre.Aplication.CrudAplication.ComboCrud;
using ProjetoAndre.Aplication.CrudAplication.ProductCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Domain.Services;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ComboControllers;

public class ComboBuildController
{
    private readonly IComboBuild _comboBuild = new ProductServices();
    private readonly ProductUpdate _productUpdate;
    private readonly ComboUpdate _comboUpdate;

    public ComboBuildController(ProductUpdate productUpdate, ComboUpdate comboUpdate)
    {
        _productUpdate = productUpdate;
        _comboUpdate = comboUpdate;
    }

    public bool ComboBuildAdd(List<ProductRequest> productRequestsList, ComboRequest comboRequest)
    {
        InternalValidation(productRequestsList, comboRequest);


        List<Product> productList = ControllerTools<Product, ProductRequest>.RequestToEntityList(productRequestsList);
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(comboRequest);

        foreach (var product in productList)
        {
            _comboBuild.AddProductToCombo(product, combo);
            _productUpdate.UpdateProduct(product);
            _comboUpdate.UpdateCombo(combo);
        }

        return true;
    }

    public bool ComboBuildRemove(List<ProductRequest> productRequestsList, ComboRequest comboRequest)
    {
        InternalValidation(productRequestsList, comboRequest);


        List<Product> productList = ControllerTools<Product, ProductRequest>.RequestToEntityList(productRequestsList);
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(comboRequest);


        foreach (var product in productList)
        {
            _comboBuild.RemoveProductFromCombo(product, combo);
            _productUpdate.UpdateProduct(product);
            _comboUpdate.UpdateCombo(combo);
        }

        return true;
    }

    private void InternalValidation(List<ProductRequest> productRequestsList, ComboRequest comboRequest)
    {
        if (productRequestsList == null)
        {
            Log.Error("Falha ao receber a lista de produtos.");
            throw new InvalidComboException("Falha ao receber a lista de produtos.");
        }
        if (comboRequest == null)
        {
            Log.Error("O combo não pode ser vazio.");
            throw new InvalidComboException("O combo não pode ser vazio.");
        }
    }
}
