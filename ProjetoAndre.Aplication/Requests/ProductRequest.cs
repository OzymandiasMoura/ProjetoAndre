namespace ProjetoAndre.Aplication.Requests;

public record ProductRequest(Guid? Id, string Name, string BarCode, string Marca, decimal CostPrice, decimal SellPrice, string? Supplier, string NCM, string CFop);
public record ProductEnsencialRequest(Guid? Id, string Name, string BarCode);
public record ProductPricesRequest(decimal CostPrice, decimal SellPrice);
public record ProductTaxesRequest(string NCM, string CFop);
public record ProductSuplierRequest(string Marca, string? Supplier);

