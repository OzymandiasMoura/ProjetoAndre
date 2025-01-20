using ProjetoAndre.Domain.Entities;

namespace ProjetoAndre.Domain.Services;

public interface IComboBuild
{
    public void AddToCombo(Product product, Combo combo);
    public void RemoveFromCombo(Product product, Combo combo);
    public decimal ProfitMargin(Product product);
}
