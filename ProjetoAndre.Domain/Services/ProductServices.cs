using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;


namespace ProjetoAndre.Domain.Services;

public class ProductServices : IComboBuild
{
    public decimal ProfitMargin(Product product)
    {
        decimal margin = product.SellPrice - product.CostPrice;
        return margin;
    }
    public void AddToCombo(Product product, Combo combo)
    {
        try
        {
            if (product.Combo != null)
            {
                throw new Errors("Produto já está em um combo");
            }
            product.Combo = combo;
            product.ComboId = combo.Id;            
            combo.AddProduct(product);
        }
        catch (Exception)
        {
            throw new Errors("Impossivel encontrar adicionar o produto. Tente mais tarde ou contate o administrador");
        }


    }
    public void RemoveFromCombo(Product product, Combo combo)
    {
        try
        {
            product.Combo = null;
            product.ComboId = Guid.Empty;
            combo.RemoveProduct(product);
        }
        catch (Exception)
        {
            throw new Errors("Impossivel encontrar remover o produto. Tente mais tarde ou contate o administrador");
        }

    }
}
