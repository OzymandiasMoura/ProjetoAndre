using ProjetoAndre.Aplication.CrudAplication.Products;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Services;

namespace ProjetoAndre.Aplication.CrudAplication.Combos;

public class ProductServiceManager
{
    public void AddProductToCombo(List<Product> products, Combo combo)
    {
        try
        {
            ComboCrudAplication comboCrudAplication = new ComboCrudAplication();
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            IComboBuild comboBuild = new ProductServices();

            foreach (var product in products)
            {
                
                comboBuild.AddToCombo(product, combo);
                Product other = product;
                Combo combo1 = combo;
                productCrudAplication.UpdateProduct(product, other);
                comboCrudAplication.Update(combo, combo1);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void RemoveProductFromCombo(List<Product> products, Combo combo)
    {
        try
        {
            ComboCrudAplication comboCrudAplication = new ComboCrudAplication();
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            IComboBuild comboBuild = new ProductServices();
            foreach (var product in products)
            {
                comboBuild.RemoveFromCombo(product, combo);
                Product other = product;
                Combo combo1 = combo;
                productCrudAplication.UpdateProduct(product, other);
                comboCrudAplication.Update(combo, combo1);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
