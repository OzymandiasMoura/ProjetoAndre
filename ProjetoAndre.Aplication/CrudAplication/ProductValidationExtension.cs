using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Domain.Entities;
using Serilog;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjetoAndre.Aplication.CrudAplication.ProductCrud;

namespace ProjetoAndre.Aplication.CrudAplication;

public static class ProductValidationExtension
{
    public static void ValidateProduct(Product product)
    {
        ProductValidationExtension.ValidatetNull(product);
        ProductValidationExtension.ValidatePrice(product);
        ProductValidationExtension.ValidateBarCode(product);
        ProductValidationExtension.ValidateNCM(product);
        ProductValidationExtension.ValidateCFop(product);
        ProductValidationExtension.ValidateConflict(product);
    }
    public static void ValidatetNull( Product product)
    {
        if (product.Name == null || product.Name == "" || product.BarCode == null || product.BarCode == "" || product.Marca == null || product.Marca == "" || product.NCM == null || product.NCM == "" || product.CFop == null || product.CFop == "" || product.SellPrice == 0 || product.CostPrice == 0)
        {
            Log.Error("Cadastro do produto está incompleto.");
            throw new Errors("Cadastro do produto está incompleto.");
        }
    }
    public static void ValidatePrice(Product request)
    {
        if (request.CostPrice < 0 || request.SellPrice < 0)
        {
            Log.Error("Preço de custo ou preço de venda não podem ser negativos.");
            throw new Errors("Preço de custo ou preço de venda não podem ser negativos.");
        }
        if (request.SellPrice < request.CostPrice)
        {
            Log.Error("Preço de venda não pode ser menor que o preço de custo.");
            throw new Errors("Preço de venda não pode ser menor que o preço de custo.");
        }
    }
    public static void ValidateBarCode(Product request)
    {
        if (request.BarCode.Length != 13 && request.BarCode.Length != 8 && request.BarCode.Length != 14)
        {
            Log.Error("Código de barras inválido.");
            throw new Errors("Código de barras inválido.");
        }
    }
    public static void ValidateNCM(Product product)
    {
        if (product.NCM.Length != 8)
        {
            Log.Error("NCM invalido.");
            throw new Errors("NCM inválido.");
        }
    }
    public static void ValidateCFop(Product product)
    {
        if (product.CFop.Length != 4)
        {
            Log.Error("CFop inválido.");
            throw new Errors("CFop inválido.");
        }
    }
    public static void ValidateConflict(Product product)
    {
        ProductRead productRead = new ProductRead();
        List<Product> list = productRead.ReadProducts();
        foreach (var item in list)
        {
            if (item.Name == product.Name)
            {
                Log.Error("Nome já cadastrado.");
                throw new Errors("Nome já cadastrado.");
            }
            if (item.BarCode == product.BarCode)
            {
                Log.Error("Código de barras já cadastrado.");
                throw new Errors("Código de barras já cadastrado.");
            }
        }

    }

    public static void ValidateProductUpdateDelete(Product product)
    {
        ProductValidationExtension.ValidatetNull(product);
        ProductValidationExtension.ValidatePrice(product);
        ProductValidationExtension.ValidateBarCode(product);
        ProductValidationExtension.ValidateNCM(product);
        ProductValidationExtension.ValidateCFop(product);
    }
}
