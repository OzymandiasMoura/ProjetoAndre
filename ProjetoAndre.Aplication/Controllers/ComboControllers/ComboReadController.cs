using ProjetoAndre.Aplication.CrudAplication.ComboCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ComboControllers;

public class ComboReadController
{
    private readonly ComboRead _comboRead;

    public ComboReadController()
    {
        _comboRead = new ComboRead();
    }

    public List<Combo> ReadComboController()
    {

        var test = _comboRead.ReadCombo();
        if (test == null)
        {
            Log.Error("Falha em passar informações para ComboRead.");
            throw new InvalidComboException("Falha em passar informações para ComboRead.");
        }
        return test;
    }
}
