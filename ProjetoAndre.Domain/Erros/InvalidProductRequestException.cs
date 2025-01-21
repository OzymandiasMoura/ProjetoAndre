namespace ProjetoAndre.Domain.Erros;

public class InvalidProductRequestException : Exception
{
    public InvalidProductRequestException() : base("O ProductRequest é invalido") { }

    public InvalidProductRequestException(string message) : base(message) { }

    public InvalidProductRequestException(string message, Exception innerException) : base(message, innerException) { }
}
