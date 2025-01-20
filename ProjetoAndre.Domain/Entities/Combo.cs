namespace ProjetoAndre.Domain.Entities;

public class Combo
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Discount { get; set; }
    public List<Product>? ProductsInCombo { get; set; }

    public Combo(){ }

    public Combo(string name, string code, decimal discount)
    {
        Id = Guid.NewGuid();
        Name = name;
        Code = code;
        Discount = discount;        
    }
    public Combo(Guid? id, string name, string code, decimal discount, List<Product>? productsInCombo)
    {
        if (id == null)
        {
            Id = Guid.NewGuid();
        }
        if (id != null)
        {
            Id = (Guid)id;
        }        
        Name = name;
        Code = code;
        Discount = discount;
        ProductsInCombo = productsInCombo;
    }

    public void AddProduct(Product product)
    {
        if (ProductsInCombo == null)
        {
            ProductsInCombo = new List<Product>();
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
        return $"Id: {Id}, Name: {Name}, Code: {Code}, Discount: {Discount}, ProductsInCombo: {ProductsInCombo}";
    }

    override public bool Equals(object? obj)
    {
        if (!(obj is Combo))
        {
            return false;
        }
        Combo combo = (Combo)obj;
        return Id == combo.Id || Name == combo.Name || Code == combo.Code;
    }

    override public int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Code);
    }

}
