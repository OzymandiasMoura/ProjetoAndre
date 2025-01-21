
namespace ProjetoAndre.Aplication.Requests;

public record ComboRequest (Guid? Id, string Name, string Code, decimal Discount, List<ProductRequest>? Products);
public record ComboEnsencialRequest(Guid? Id, string Name, string Code);
public record ComboProductsRequest(List<ProductRequest>? Products);


