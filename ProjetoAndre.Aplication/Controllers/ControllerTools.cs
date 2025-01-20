using ProjetoAndre.Aplication.CrudAplication.Combos;
using ProjetoAndre.Aplication.CrudAplication.Products;
using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Entities;

namespace ProjetoAndre.Aplication.Controllers;

public static class ControllerTools<T, U>
{
    public static List<T> RequestToEntityList(List<U> requests)
    {
        List<T> combos = new List<T>();
        foreach (var request in requests)
        {
            T? combo = RequestToEntity(request);
            if (combo != null)
            {
                combos.Add(combo);
            }
        }
        return combos;
    }
    public static List<U> EntityToRequestList(List<T> combos)
    {
        List<U> requests = new List<U>();
        foreach (var combo in combos)
        {
            U? comboRequest = EntityToRequest(combo);
            if (comboRequest != null)
            {
                requests.Add(comboRequest);
            }
        }
        return requests;
    }

    public static T? RequestToEntity(U request)
    {
        if (request == null)
        {
            return default;
        }

        //COMBOS

        if (typeof(U) == typeof(ComboRequest) && typeof(T) == typeof(Combo))
        {
            ComboRequest? comboRequest = request as ComboRequest;
            ComboCrudAplication comboCrudAplication = new ComboCrudAplication();
            List<Combo> combos = comboCrudAplication.ReadCombos();
            if (comboRequest is null)
            {
                throw new ArgumentException("Request está vazio.");
            } 

            if (comboRequest.Products == null)
            {
                foreach (var item in combos)
                {
                    if (item.Id == comboRequest.Id || item.Code == comboRequest.Code)
                    {                        
                        return (T)(object)item;
                    } 
                }
                Combo combo = new Combo(comboRequest.Name, comboRequest.Code, comboRequest.Discount);
                return (T)(object)combo;
            }
            if (comboRequest.Products != null)
            {
                List<Product> products = new List<Product>();
                foreach (var item in combos)
                {
                    if (item.Id == comboRequest.Id || item.Code == comboRequest.Code)
                    {                        
                        return (T)(object)item;
                    }
                }
                Combo combo = new Combo(comboRequest.Id, comboRequest.Name, comboRequest.Code, comboRequest.Discount, products);
                return (T)(object)combo;
            }
        }

        //PRODUCTS

        if (typeof(U) == typeof(ProductRequest) && typeof(T) == typeof(Product))
        {
            ProductRequest? productRequest = request as ProductRequest;
            ProductCrudAplication productCrudAplication = new ProductCrudAplication();
            List<Product> products = productCrudAplication.ReadProducts();
            foreach (var item in products)
            {
                if (item.Id == productRequest.Id || item.BarCode == productRequest.BarCode || item.Name == productRequest.Name)
                {                    
                    return (T)(object)item;
                }
            }
            Product product = new Product(productRequest.Name, productRequest.BarCode, productRequest.Marca, productRequest.CostPrice, productRequest.SellPrice, productRequest.Supplier, productRequest.NCM, productRequest.CFop);
            return (T)(object)product;
        }
        return default;
    }
    public static U? EntityToRequest(T entity)
    {

        //COMBOS

        if (typeof(U) == typeof(ComboRequest) && typeof(T) == typeof(Combo))
        {
            Combo? combo = entity as Combo;
            if (combo == null)
            {
                return default;
            }
            if (combo.ProductsInCombo == null)
            {
                ComboRequest request = new ComboRequest(combo.Id, combo.Name, combo.Code, combo.Discount, null);
                return (U)(object)request;
            }
            if (combo.ProductsInCombo != null)
            {
                List<ProductRequest> productRequests = new List<ProductRequest>();
                foreach (var item in combo.ProductsInCombo)
                {
                    ProductRequest productRequest = new ProductRequest(item.Id, item.Name, item.BarCode, item.Marca, item.CostPrice, item.SellPrice, item.Supplier, item.NCM, item.CFop);
                    productRequests.Add(productRequest);
                }
                ComboRequest request = new ComboRequest(combo.Id, combo.Name, combo.Code, combo.Discount, productRequests);
                return (U)(object)request;
            }
        }

        //PRODUCTS

        if (typeof(U) == typeof(ProductRequest) && typeof(T) == typeof(Product))
        {
            Product? product = entity as Product;
            if (product == null)
            {
                return default;
            }
            ProductRequest request = new ProductRequest(product.Id, product.Name, product.BarCode, product.Marca, product.CostPrice, product.SellPrice, product.Supplier, product.NCM, product.CFop);
            return (U)(object)request;
        }

        return default;
    }
}
