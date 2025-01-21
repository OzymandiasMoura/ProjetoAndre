using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Services.Common;
using ProjetoAndre.Infrastruct.Context;

namespace ProjetoAndre.Infrastruct.Routes;

public class ComboFind : IFind<Combo>
{
    public Combo FindWithEntity(Combo entity)
    {
        AppDBContext context = new AppDBContext();
        var combo = context.combos;
        foreach (var item in combo)
        {
            if (item == entity)
            {
                return item;
            }
        }

        throw new Exception("Não foi capaz de realizar as buscas");
    }

    public Combo FindWithId(Guid id)
    {
        AppDBContext context = new AppDBContext();
        var combos = context.combos;
        foreach (var comb in combos)
        {
            if (comb.IdCombo == id)
            {
                return comb;
            }
        }
        throw new Exception("Não foi capaz de realizar as buscas");
    }
}
