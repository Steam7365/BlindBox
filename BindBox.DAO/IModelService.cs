using BindBox.Models;

namespace BindBox.DAO
{
    public interface IModelService<T>
    {
        IQueryable<T> ModelQueryable { get;}
        Task<bool> CreateAsync(T t);
        Task<bool> UpdateAsync(T t);
        Task<bool> DeleteAsync(int? t);

        Task<T> SingAsync(int? t);
    }
}