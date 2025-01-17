using ProjetoAndre.Domain.Entities;

namespace ProjetoAndre.Domain.Services.ProductService;

public class ProductServices
{
    public void UpdateSellPrice(Product product, decimal price)
    {
        product.UpdateSellPrice(price);
    }

    public void UpdateCostPrice(Product product, decimal price)
    {
        product.UpdateCostPrice(price);
    }

    public decimal ProfitMargin(Product product)
    {
        decimal margin = product.SellPrice - product.CostPrice;        
        return margin;
    }

}
