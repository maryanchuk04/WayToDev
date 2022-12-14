namespace WayToDev.Core.Interfaces.DAOs.Base;

public interface IDao<T>
    where T : class
{
    T Insert(T entity);
    T Update(T entity);
    T Delete(T entity);
}