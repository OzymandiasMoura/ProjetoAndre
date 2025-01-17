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
            switch(op)
            {
                case 1:
                    CreateProductController(request);
                    break;
                case 2:
                    UpdateProductController(request);
                    break;
                case 3:
                    DeleteProductController(request);
                    break;
                case 4:
                    ReadProductsController();
                    break;
                default:
                    Log.Error("Opção inválida");
                    throw new Errors("Opção inválida");
            }
        }

        public void CreateProductController(ProductRequest request)
        {            
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.CreateProduct(request);
        }
        public void UpdateProductController(ProductRequest request)
        {
            
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.UpdateProduct(request);
        }
        public void DeleteProductController(ProductRequest request)
        {            
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            productCrudAplication.DeleteProduct(request);
        }
        public List<Product> ReadProductsController()
        {
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            return productCrudAplication.ReadProducts();
        }
    }
}

