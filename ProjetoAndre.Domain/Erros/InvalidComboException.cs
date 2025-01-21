
namespace ProjetoAndre.Domain.Erros;

public class InvalidComboException : Exception
{
    public InvalidComboException() : base("O combo é invalido") { }

    public InvalidComboException(string message) : base(message) { }

    public InvalidComboException(string message, Exception innerException) : base(message, innerException) { }
}
