using ProjetoAndre.Aplication.Requests;
using ProjetoAndre.Domain.Erros;
using ProjetoAndre.Domain.Entities;
using Serilog;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProjetoAndre.Aplication.CrudAplication.Products.ProductValidation;

public static class ProductValidationExtension
{
    public static void ValidateProduct(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        productCrudAplication.ValidatetNull(request);
        productCrudAplication.ValidatePrice(request);
        productCrudAplication.ValidateBarCode(request);
        productCrudAplication.ValidateNCM(request);
        productCrudAplication.ValidateCFop(request);
        productCrudAplication.ValidateConflict(request);
    }
    public static void ValidatetNull(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        if (request. Name == null || request.Name == "" || request.BarCode == null || request.BarCode == "" || request.Marca == null || request.Marca == "" || request.NCM == null || request.NCM == "" || request.CFop == null || request.CFop == "" || request.SellPrice == 0 || request.CostPrice == 0)
        {            
            Log.Error("Cadastro do produto está incompleto.");
            throw new Errors("Cadastro do produto está incompleto.");
        }        
    }
    public static void ValidatePrice(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        if (request.CostPrice < 0 || request.SellPrice < 0)
        {
            Log.Error("Preço de custo ou preço de venda não podem ser negativos.");
            throw new Errors("Preço de custo ou preço de venda não podem ser negativos.");
        }
        if(request.SellPrice < request.CostPrice)
        {
            Log.Error("Preço de venda não pode ser menor que o preço de custo.");
            throw new Errors("Preço de venda não pode ser menor que o preço de custo.");
        }
    }
    public static void ValidateBarCode(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        if (request.BarCode.Length != 13 && request.BarCode.Length != 8 && request.BarCode.Length != 14)
        {
            Log.Error("Código de barras inválido.");
            throw new Errors("Código de barras inválido.");
        }
    }
    public static void ValidateNCM(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        if (request.NCM.Length != 8)
        {
            Log.Error("NCM invalido.");            
            throw new Errors("NCM inválido.");
        }
    }
    public static void ValidateCFop(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        if (request.CFop.Length != 4)
        {
            Log.Error("CFop inválido.");
            throw new Errors("CFop inválido.");
        }
    }
    public static void ValidateConflict(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        
        List<Product> list = productCrudAplication.ReadProducts();
        foreach (var item in list)
        {
            if (item.Name == request.Name)
            {
                Log.Error("Nome já cadastrado.");
                throw new Errors("Nome já cadastrado.");
            }
            if (item.BarCode == request.BarCode)
            {
                Log.Error("Código de barras já cadastrado.");
                throw new Errors("Código de barras já cadastrado.");
            }
        }

    }

    public static void ValidateProductUpdateDelete(this ProductCrudAplication productCrudAplication, ProductRequest request)
    {
        productCrudAplication.ValidatetNull(request);
        productCrudAplication.ValidatePrice(request);
        productCrudAplication.ValidateBarCode(request);
        productCrudAplication.ValidateNCM(request);
        productCrudAplication.ValidateCFop(request);        
    }
}
