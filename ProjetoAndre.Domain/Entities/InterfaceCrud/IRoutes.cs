namespace ProjetoAndre.Domain.Entities.InterfaceCrud;

public interface IRoutes<T, U>
{
    public Task Create(T entities, U context);

    public List<T> Read(U context);


    public Task Update(T entities, U context);


    public Task Delete(T entities, U context);

}
