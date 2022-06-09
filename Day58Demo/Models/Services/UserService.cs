using Day58Demo.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Day58Demo.Models.Services;

public class UserService
{
    public async Task<List<User>> GetAllAsync()
    {
        using var context = new ApplicationDbContext();

        var users = 
            from user in context.Users
            select user;

        return await users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        using var context = new ApplicationDbContext();

        var userById =
            from user in context.Users
            where user.Id == id
            select user;

        return await userById.SingleOrDefaultAsync();
    }

    public async Task CreateAsync(User user)
    {
        using var context = new ApplicationDbContext();

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        using var context = new ApplicationDbContext();

        // Shubham Pandharpote
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = new ApplicationDbContext();

        var userToDelete = await
            (from user in context.Users
            where user.Id == id
            select user).SingleAsync();

        context.Users.Remove(userToDelete);

        await context.SaveChangesAsync();
    }
}