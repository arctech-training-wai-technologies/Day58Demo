namespace Day58Demo.Models.Services;

public interface ICrudService<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task DeleteAsync(int id);
}