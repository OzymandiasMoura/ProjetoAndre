namespace ProjetoAndre.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; init; }
        public string Name { get;  set; }
        public string BarCode { get;  set; }
        public string Marca { get;  set; }
        public decimal CostPrice { get;  set; }
        public decimal SellPrice { get;  set; }
        public string? Supplier { get;  set; }
        public string NCM { get;  set; }
        public string CFop { get;  set; }

        public Product()
        {           
        }

        public Product(string name, string barCode, string marca, decimal costPrice, decimal sellPrice, string? supplier, string nCM, string cFop)
        {
            Id = Guid.NewGuid();
            Name = name;
            BarCode = barCode;
            Marca = marca;
            CostPrice = costPrice;
            SellPrice = sellPrice;
            Supplier = supplier;
            NCM = nCM;
            CFop = cFop;
        }

        public void Update(string name, string barCode, string marca, decimal costPrice, decimal sellPrice, string? supplier, string nCM, string cFop)
        {
            Name = name;
            BarCode = barCode;
            Marca = marca;
            CostPrice = costPrice;
            SellPrice = sellPrice;
            Supplier = supplier;
            NCM = nCM;
            CFop = cFop;
        }

        public void UpdateSellPrice(decimal price)
        {
            SellPrice = price;
        }

        public void UpdateCostPrice(decimal price)
        {
            CostPrice = price;
        }

        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, BarCode: {BarCode}, Marca: {Marca}, CostPrice: {CostPrice}, SellPrice: {SellPrice}, Supplier: {Supplier}, NCM: {NCM}, CFop: {CFop}";
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Product))
            {
                return false;
            }            
            Product other = new Product();
            return Id == other.Id && Name == other.Name && BarCode == other.BarCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, BarCode);
        }       
    }
}
