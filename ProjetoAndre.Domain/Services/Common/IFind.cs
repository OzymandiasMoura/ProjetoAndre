namespace ProjetoAndre.Domain.Services.Common;

public interface IFind<T>
{
    public T FindWithEntity(T entity);
    public T FindWithId(Guid id);
}

