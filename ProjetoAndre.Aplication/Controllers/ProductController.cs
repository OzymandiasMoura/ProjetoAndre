using ProjetoAndre.Aplication.CrudAplication.Products;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers
{
    public class ProductController
    {
        public void CrudProductController(ProductRequest request, int op)
        {
            Product? product = ControllerTools<Product, ProductRequest>.RequestToEntity(request);

            switch (op)
            {
                case 1:
                    CreateProductController(product);
                    break;
                case 2:
                    UpdateProductController(product);
                    break;
                case 3:
                    DeleteProductController(product);
                    break;
                case 4:
                    ReadProductsController();
                    break;
                default:
                    Log.Error("Opção inválida");
                    throw new Errors("Opção inválida");
            }
        }

        public void CreateProductController(Product product)
        {
            if (product == null)
            {
                Log.Error("Produto nulo");
                throw new Errors("Produto nulo");
            }
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.CreateProduct(product);
        }
        public void UpdateProductController(Product product)
        {
            if (product == null)
            {
                Log.Error("Produto nulo");
                throw new Errors("Produto nulo");
            }
         
        }
        public void DeleteProductController(Product product)
        {
            if (product == null)
            {
                Log.Error("Produto nulo");
                throw new Errors("Produto nulo");
            }
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.DeleteProduct(product);
        }
        public List<ProductRequest> ReadProductsController()        
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            List<Product> products = productCrudAplication.ReadProducts();
            List<ProductRequest> productRequests = ControllerTools<Product, ProductRequest>.EntityToRequestList(products);

            return productRequests;
        }
    }
}

