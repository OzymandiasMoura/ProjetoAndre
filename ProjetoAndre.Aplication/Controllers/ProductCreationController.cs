using ProjetoAndre.Aplication.CrudAplication.ProductCrud;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;
using ProjetoAndre.Domain.Erros;
using Serilog;

namespace ProjetoAndre.Aplication.Controllers
{
    public class ProductCreationController
    {
        private readonly ProductCreate _productCreate;
        private ProductRequest _productRequest;
       
        public ProductCreationController(ProductCreate productCreate, ProductRequest request)
        {
            _productCreate = productCreate;
            _productRequest = request;
        } 

        
        public void CreateProductController()
        {
            Product? product = ControllerTools<Product, ProductRequest>.RequestToEntity(_productRequest);
            if (product == null)
            {
                Log.Error("ProductRequest falhou em passar as informações para o CreateController.");
                throw new InvalidProductRequestException("ProductRequest falhou em passar as informações para o CreateController.");
            }
            _productCreate.CreateProduct(product);                   
        }        
    }
}

