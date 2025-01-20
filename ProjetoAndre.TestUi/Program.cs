using System.Xml;
using ProjetoAndre.Aplication.Controllers;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Infrastruct.Context;
using Serilog.Core;

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


        
       
    }

    static void CrudComboTest()
    {

        Console.WriteLine("Escolha a opção que deseja testar: \n");
        Console.WriteLine("1 - Criar Combo\n");
        Console.WriteLine("2 - Listar Combo\n");
        Console.WriteLine("3 - Atualizar Combo\n");
        Console.WriteLine("4 - Deletar Combo\n");
        int resp1 = int.Parse(Console.ReadLine());

        if (resp1 == 1)
        {
            Console.WriteLine("Nome");
            string name = Console.ReadLine();
            Console.WriteLine("Code");
            string code = Console.ReadLine();
            Console.WriteLine("Discount");
            decimal discount = decimal.Parse(Console.ReadLine());

            ComboRequest comboRequest = new ComboRequest(null, name, code, discount, null);
            ComboController comboController = new ComboController();
            comboController.CreateController(comboRequest);

        }
        else if (resp1 == 2)
        {
            ComboController comboController = new ComboController();
            List<ComboRequest> list = comboController.ReadController();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
        else if (resp1 == 3)
        {
            Console.WriteLine("Nome");
            string name = Console.ReadLine();
            Console.WriteLine("Code");
            string code = Console.ReadLine();
            Console.WriteLine("Discount");
            decimal discount = decimal.Parse(Console.ReadLine());


            ComboRequest request = new ComboRequest(null, name, code, discount, null);
            ComboController comboController = new ComboController();
            comboController.UpdateController(request);

        }
        else if (resp1 == 4)
        {
            Console.WriteLine("Nome");
            string name = Console.ReadLine();
            Console.WriteLine("Code");
            string code = Console.ReadLine();
            Console.WriteLine("Discount");
            decimal discount = decimal.Parse(Console.ReadLine());

            ComboRequest comboRequest = new ComboRequest(null, name, code, discount, null);
            ComboController comboController = new ComboController();
            comboController.DeleteController(comboRequest);

        }
    }

    static void ProductTest()
    {
        Console.WriteLine("Escolha a opção que deseja testar: \n");
        Console.WriteLine("1 - Criar Produto\n");
        Console.WriteLine("2 - Atualizar Produto\n");
        Console.WriteLine("3 - Deletar Produto\n");
        Console.WriteLine("4 - Listar Produtos\n");
        int resp1 = int.Parse(Console.ReadLine());

        if (resp1 == 0)
        {
            Console.WriteLine("Por favor digite uma opção válida");
        }
        else if (resp1 == 1)
        {
            Console.WriteLine("Nome");
            string name = Console.ReadLine();
            Console.WriteLine("BarCode");
            string barCode = Console.ReadLine();
            Console.WriteLine("Marca");
            string marca = Console.ReadLine();
            Console.WriteLine("Preço de Custo");
            decimal costPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Preço de Venda");
            decimal sellPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Fornecedor");
            string supplier = Console.ReadLine();
            Console.WriteLine("Ncm");
            string ncm = Console.ReadLine();
            Console.WriteLine("Cfop");
            string cfop = Console.ReadLine();
            ProductRequest productRequest = new ProductRequest(null, name, barCode, marca, costPrice, sellPrice, supplier, ncm, cfop);

            ProductController productController = new ProductController();
            productController.CrudProductController(productRequest, 1);
        }
        else if (resp1 == 2)
        {
            Console.WriteLine("Id");
            Guid id = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Nome");
            string name = Console.ReadLine();
            Console.WriteLine("BarCode");
            string barCode = Console.ReadLine();
            Console.WriteLine("Marca");
            string marca = Console.ReadLine();
            Console.WriteLine("Preço de Custo");
            decimal costPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Preço de Venda");
            decimal sellPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Fornecedor");
            string supplier = Console.ReadLine();
            Console.WriteLine("Ncm");
            string ncm = Console.ReadLine();
            Console.WriteLine("Cfop");
            string cfop = Console.ReadLine();
            ProductRequest productRequest = new(id, name, barCode, marca, costPrice, sellPrice, supplier, ncm, cfop);
            ProductController productController = new ProductController();
            productController.CrudProductController(productRequest, 2);
        }
        else if (resp1 == 3)
        {
            Console.WriteLine("Id");
            Guid id = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Nome");
            string name = Console.ReadLine();
            Console.WriteLine("BarCode");
            string barCode = Console.ReadLine();
            Console.WriteLine("Marca");
            string marca = Console.ReadLine();
            Console.WriteLine("Preço de Custo");
            decimal costPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Preço de Venda");
            decimal sellPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Fornecedor");
            string supplier = Console.ReadLine();
            Console.WriteLine("Ncm");
            string ncm = Console.ReadLine();
            Console.WriteLine("Cfop");
            string cfop = Console.ReadLine();
            ProductRequest productRequest = new ProductRequest(id, name, barCode, marca, costPrice, sellPrice, supplier, ncm, cfop);
            ProductController productController = new ProductController();
            productController.CrudProductController(productRequest, 3);
        }
        else if (resp1 == 4)
        {
            ProductController productController = new ProductController();
            var products = productController.ReadProductsController();
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
