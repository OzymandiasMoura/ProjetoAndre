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

        var combo3 = new ComboRequest(null, "Combo 4 Latinhas", "C2", 4, null);

        ComboDeleteController comboDeleteController = new ComboDeleteController(combo3);
        comboDeleteController.DeleteComboController();  











    }
}
