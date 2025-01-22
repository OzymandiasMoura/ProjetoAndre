using ProjetoAndre.Aplication.Controllers.ComboControllers;
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

        var combo3 = new ComboRequest(null, "Combo 3 Latinhas", "C1", 2, null);
        var product1 = new ProductRequest(null, "Cerveja", "12345678", "Skol", 2, 3, "Ambev", "12345678", "1234");
        var product2 = new ProductRequest(null, "Cerveja", "12345678", "Skol", 2, 3, "Ambev", "12345678", "1234");
        var product3 = new ProductRequest(null, "Cerveja", "12345678", "Skol", 2, 3, "Ambev", "12345678", "1234");

        List<ProductRequest> productRequests = new List<ProductRequest>();
        productRequests.Add(product1);
        productRequests.Add(product2);
        productRequests.Add(product3);



        ComboBuildController comboBuildController = new ComboBuildController(productRequests, combo3);
        comboBuildController.ComboBuildRemove();











    }
}
