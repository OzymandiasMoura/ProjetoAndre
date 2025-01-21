namespace ProjetoAndre.Domain.Erros;

public class DataConnectionFailureException : Exception
{
    public DataConnectionFailureException() : base("Falha na conexão com a database.") { }

    public DataConnectionFailureException(string message) : base(message) { }

    public DataConnectionFailureException(string message, Exception innerException) : base(message, innerException) { }

}
