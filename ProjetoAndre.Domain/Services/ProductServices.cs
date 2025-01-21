using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;

namespace ProjetoAndre.Domain.Services;

public class ProductServices : IComboBuild
{
    public decimal ProfitMarginInCombo(Combo combo)
    {
        if (combo is null)
        {
            throw new InvalidComboException("Combo não informado.");
        }
        if (combo.ProductsInCombo == null)
        {
            throw new InvalidComboException("Combo não possui produtos cadastrados.");
        }
        List<Product> products = (List<Product>)combo.ProductsInCombo;
        decimal total = combo.ProductsInCombo.Sum(p => this.ProfitMargin(p));
        decimal totalcost = combo.ProductsInCombo.Sum(p => p.CostPrice);

        var finalresult = total - combo.Discount;
        if (finalresult < totalcost)
        {
            throw new InvalidComboException("Combo está abaixo do preço minimo.");
        }
        return finalresult;
    }

    public decimal ProfitMargin(Product product)
    {
        decimal margin = product.SellPrice - product.CostPrice;
        return margin;
    }


    public void AddProductToCombo(Product product, Combo combo)
    {
        try
        {
            combo.AssociateProduct(product);
            product.AssociateWithCombo(combo);
        }
        catch (Exception)
        {
            throw new InvalidComboException("Impossivel adicionar o produto do combo.");
        }
    }


    public void RemoveProductFromCombo(Product product, Combo combo)
    {
        try
        {
            combo.RemoveProduct(product);
            product.DesassociateWithCombo();
        }
        catch (Exception)
        {
            throw new InvalidComboException("Impossivel remover o produto do combo.");
        }
    }


}
