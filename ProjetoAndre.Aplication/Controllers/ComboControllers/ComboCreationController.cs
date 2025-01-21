using ProjetoAndre.Aplication.Controllers.Common;
using ProjetoAndre.Aplication.CrudAplication.ComboCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ComboControllers;

public class ComboCreationController
{
    private readonly ComboCreate _comboCreate;
    private ComboRequest _comboRequest;

    public ComboCreationController(ComboRequest comboRequest)
    {
        _comboRequest = comboRequest;
        _comboCreate = new ComboCreate();
    }

    public void CreateComboController()
    {
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(_comboRequest);
        if (combo == null)
        {
            Log.Error("ComboRequest falhou em passar as informações para CreationController.");
            throw new InvalidComboException("ComboRequest falhou em passar as informações para CreationController.");
        }

        var test = _comboCreate.CreateCombo(combo);
        if (test == null)
        {
            Log.Error("Falha em passar informações para ComboCreate.");
            throw new InvalidComboException("Falha em passar informações para ComboCreate.");
        }
    }
}
