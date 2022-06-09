namespace Day58Demo.Models.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}