using ProjetoAndre.Aplication.Controllers;
using ProjetoAndre.Aplication.Requests;

namespace ProjetoAndre.TesteUi;

class Program
{
    static void Main(string[] args)
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
            ProductRequest productRequest = new ProductRequest(name, barCode, marca, costPrice, sellPrice, supplier, ncm, cfop);

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
            ProductRequest productRequest = new ProductRequest(name, barCode, marca, costPrice, sellPrice, supplier, ncm, cfop);
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
            ProductRequest productRequest = new ProductRequest(name, barCode, marca, costPrice, sellPrice, supplier, ncm, cfop);
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