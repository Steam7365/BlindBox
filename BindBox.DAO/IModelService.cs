using BindBox.Models;

namespace BindBox.DAO
{
    public interface IModelService<T>
    {
        IQueryable<T> ModelQueryable { get;}
        Task CreateAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(int? t);

        Task<T> SingAsync(int? t);
    }
}