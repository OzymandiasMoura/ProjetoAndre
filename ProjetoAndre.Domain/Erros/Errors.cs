using System.Reflection;

namespace ProjetoAndre.Domain.Erros
{
    public class Errors : Exception
    {
        public Errors()
        {           
        }

        public Errors(string message) : base(message)
        {

        }      
    }
}
