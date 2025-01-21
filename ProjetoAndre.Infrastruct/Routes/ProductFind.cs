
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Infrastruct.Context;

namespace ProjetoAndre.Infrastruct.Routes;

public class ProductFind
{
    public Product FindWithEntity(Product entity)
    {
        AppDBContext context = new AppDBContext();
        var products = context.products;
        foreach (var item in products)
        {
            if (item == entity)
            {
                return item;
            }
        }

        throw new Exception("Não foi capaz de realizar as buscas");
    }

    public Product FindWithId(Guid id)
    {
        AppDBContext context = new AppDBContext();
        var products = context.products;
        foreach (var item in products)
        {
            if (item.IdProduct == id)
            {
                return item;
            }
        }
        throw new Exception("Não foi capaz de realizar as buscas");
    }
}

