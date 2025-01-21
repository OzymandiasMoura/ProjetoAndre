using ProjetoAndre.Aplication.Controllers.Common;
using ProjetoAndre.Aplication.CrudAplication.ComboCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ComboControllers;

public class ComboDeleteController
{
    private readonly ComboDelete _comboDelete;
    private ComboRequest _comboRequest;

    public ComboDeleteController(ComboRequest comboRequest)
    {
        _comboRequest = comboRequest;
        _comboDelete = new ComboDelete();
    }

    public void DeleteComboController()
    {
        Combo? combo = ControllerTools<Combo, ComboRequest>.RequestToEntity(_comboRequest);
        if (combo == null)
        {
            Log.Error("ComboRequest falhou em passar as informações para CreationController.");
            throw new InvalidComboException("ComboRequest falhou em passar as informações para CreationController.");
        }

        var test = _comboDelete.DeleteCombo(combo);
        if (test == false)
        {
            Log.Error("Falha em passar informações para ComboCreate.");
            throw new InvalidComboException("Falha em passar informações para ComboCreate.");
        }
    }
}
