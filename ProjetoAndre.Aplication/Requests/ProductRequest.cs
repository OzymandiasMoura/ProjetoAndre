namespace ProjetoAndre.Aplication.Requests;

public record ProductRequest(string Name, string BarCode, string Marca, decimal CostPrice, decimal SellPrice, string? Supplier, string NCM, string CFop);

