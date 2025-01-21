using ProjetoAndre.Domain.Erros;

namespace ProjetoAndre.Domain.Entities;

public class Product
{
    public Guid IdProduct { get; init; }
    public string Name { get;  set; }
    public string BarCode { get;  set; }
    public string Marca { get;  set; }
    public decimal CostPrice { get;  set; }
    public decimal SellPrice { get;  set; }
    public string? Supplier { get;  set; }
    public string NCM { get;  set; }
    public string CFop { get;  set; }
    public Guid? ComboId { get;  set; }
    public Combo Combo { get;  set; }

    public Product()
    {
        
    }

    public Product(Guid? id, string name, string barCode, string marca, decimal costPrice, decimal sellPrice, string? supplier, string nCM, string cFop)
    {       
        IdProduct = id ?? Guid.NewGuid();
        Name = name;
        BarCode = barCode;
        Marca = marca;
        CostPrice = costPrice;
        SellPrice = sellPrice;
        Supplier = supplier;
        NCM = nCM;
        CFop = cFop;
        
    }      
    public void AssociateWithCombo(Combo combo)
    {
        if(combo == null)
        {
            throw new InvalidComboException();
        }
        Combo = combo;
        ComboId = Combo.IdCombo;
        
        //Descobrir por que isso está dando errado.
        //Por algum motivo o Id do combo não está sendo salvo. Isso é um problema. Poderia usar uma chave alternativa talvez.
    }
    public void DesassociateWithCombo()
    {
        ComboId = null;
        Combo = null;
    }

    override public string ToString()
    {
        return $"Id: {IdProduct}, Name: {Name}, BarCode: {BarCode}, Marca: {Marca}, CostPrice: {CostPrice}, SellPrice: {SellPrice}, Supplier: {Supplier}, NCM: {NCM}, CFop: {CFop}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Product other)
        {
            return false;
        }        
        return IdProduct == other.IdProduct || Name == other.Name || BarCode == other.BarCode;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdProduct, Name, BarCode);
    }       
}
