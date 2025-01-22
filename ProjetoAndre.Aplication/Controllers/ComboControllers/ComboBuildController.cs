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
    private readonly IComboBuild _comboBuild;
    private readonly ProductUpdate _productUpdate;
    private readonly ComboUpdate _comboUpdate;
    private List<ProductRequest> _productRequests;
    private ComboRequest _comboRequest;

    public ComboBuildController(List<ProductRequest> productRequests, ComboRequest comboRequest)
    {
        _comboBuild = new ProductServices();
        _productUpdate = new ProductUpdate();
        _comboUpdate = new ComboUpdate();
        _productRequests = productRequests;
        _comboRequest = comboRequest;
    }

    public bool ComboBuildAdd()
    {
        InternalValidation(_productRequests, _comboRequest);

        List<Product> productList = ControllerTools<Product, ProductRequest>.RequestToEntityList(_productRequests);
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(_comboRequest);
        if (combo == null)
        {
            Log.Error("Erro na passagem de ComboRequest dentro do Controlador");
            throw new InvalidComboException("Erro na passagem de ComboRequest dentro do Controlador");
        }

        foreach (var product in productList)
        {
            _comboBuild.AddProductToCombo(product, combo);
            var test = _productUpdate.UpdateProduct(product);
            var test2 = _comboUpdate.UpdateCombo(combo);

            if (test == false || test2 == false)
            {
                Log.Error("Falha ao passar as informações do controlador para a IComboBuild");
                throw new DataConnectionFailureException("Falha ao passar as informações do controlador para a IComboBuild");
            }
        }

        return true;
    }

    public bool ComboBuildRemove()
    {
        InternalValidation(_productRequests, _comboRequest);
        List<Product> productList = ControllerTools<Product, ProductRequest>.RequestToEntityList(_productRequests);
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(_comboRequest);
        if (combo == null)
        {
            Log.Error("Erro na passagem de ComboRequest dentro do Controlador");
            throw new InvalidComboException("Erro na passagem de ComboRequest dentro do Controlador");
        }
        foreach (var product in productList)
        {
            _comboBuild.RemoveProductFromCombo(product, combo);
            var test = _productUpdate.UpdateProduct(product);
            var test2 = _comboUpdate.UpdateCombo(combo);
            if (test == false || test2 == false)
            {
                Log.Error("Falha ao passar as informações do controlador para a IComboBuild");
                throw new DataConnectionFailureException("Falha ao passar as informações do controlador para a IComboBuild");
            }
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
