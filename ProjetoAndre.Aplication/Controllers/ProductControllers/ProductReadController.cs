using ProjetoAndre.Aplication.CrudAplication.ProductCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers.ProductControllers;

public class ProductReadController
{
    private readonly ProductRead _productRead = new ProductRead();

    public ProductReadController() { }

    public List<Product> ReadProductController()
    {
        var test = _productRead.ReadProducts();
        if (test == null)
        {
            Log.Error("Nenhum produto está cadastrado.");
            throw new InvalidProductRequestException("Nenhum produto está cadastrado.");
        }
        return test;
    }
}
