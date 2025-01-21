namespace ProjetoAndre.Domain.Entities;

public class Combo
{
    public Guid IdCombo { get; init; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Discount { get; set; }
    public ICollection<Product> ProductsInCombo { get; set; }

    public Combo()
    {
        
    }

    public Combo(string name, string code, decimal discount)
    {
        IdCombo = Guid.NewGuid();
        Name = name;
        Code = code;
        Discount = discount;        
    }
    public Combo(string name, string code, decimal discount, List<Product>? productsInCombo)
    {
        IdCombo = Guid.NewGuid();
        Name = name;
        Code = code;
        Discount = discount;
        ProductsInCombo = productsInCombo;
    }

    public void AssociateProduct(Product product)
    {
        if(ProductsInCombo == null)
        {
            ProductsInCombo = new List<Product>();
            ProductsInCombo.Add(product);
        }
        ProductsInCombo.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        if (ProductsInCombo == null)
        {
            return;
        }
        ProductsInCombo.Remove(product);
    }

    override public string ToString()
    {
        return $"Id: {IdCombo}, Name: {Name}, Code: {Code}, Discount: {Discount}, ProductsInCombo: {ProductsInCombo}";
    }

    override public bool Equals(object? obj)
    {
        if (!(obj is Combo))
        {
            return false;
        }
        if(obj is not Combo other)
        {
            return false;
        }
        
        return IdCombo == other.IdCombo || Name == other.Name || Code == other.Code;
    }

    override public int GetHashCode()
    {
        return HashCode.Combine(IdCombo, Name, Code);
    }

}
