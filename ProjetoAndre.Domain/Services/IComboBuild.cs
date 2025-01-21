using ProjetoAndre.Domain.Entities;

namespace ProjetoAndre.Domain.Services;

public interface IComboBuild
{
    public void AddProductToCombo(Product product, Combo combo);
    public void RemoveProductFromCombo(Product product, Combo combo);
}

