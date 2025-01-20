
namespace ProjetoAndre.Aplication.Requests;

public record ComboRequest (Guid? Id, string Name, string Code, decimal Discount, List<ProductRequest>? Products);

