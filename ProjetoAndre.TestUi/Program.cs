using ProjetoAndre.Aplication.Controllers;
using ProjetoAndre.Aplication.CrudAplication.ComboCrud;
using ProjetoAndre.Aplication.CrudAplication.ProductCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Infrastruct.Context;


namespace ProjetoAndre.TesteUi;

class Program
{
    static void Main(string[] args)
    {
        Domain.Erros.Logger.LoggerConfig loggerConfig = new Domain.Erros.Logger.LoggerConfig();
        var context = new AppDBContext();

        if (context.TestConnection())
        {
            Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso");
        }
        else
        {
            Console.WriteLine("Erro ao conectar com o banco de dados");
        }


        ComboRequest comboRequest = new ComboRequest(null, "Combo 3 Latinhas", "C1", 2, new List<ProductRequest>());
        ProductRequest product = new ProductRequest(null, "Cerveja", "12345678", null, 2, 1, null, null, null);
        comboRequest.Products.Add(product);
        List<ProductRequest> productRequests = comboRequest.Products;


        ProductUpdate productUpdate = new ProductUpdate();
        ComboUpdate comboUpdate = new ComboUpdate();
        ComboBuildController buildController = new ComboBuildController(productUpdate, comboUpdate);

        buildController.ComboBuildAdd(productRequests, comboRequest);



    }
}
