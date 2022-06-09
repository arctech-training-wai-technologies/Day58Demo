using Day58Demo.Models.Data;
using Day58Demo.Models.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Day58Demo.Models.Services;

public class DepartmentService : ICrudService<Department>
{
    public async Task<List<Department>> GetAllAsync()
    {
        using var _context = new ApplicationDbContext();
        var departments = await _context.Departments.ToListAsync();

        return departments;
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        using var _context = new ApplicationDbContext();
        if (_context.Departments == null)
        {
            throw new EntityMissingException("Department dbset is missing");
        }

        var department = await _context.Departments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (department == null)
        {
            throw new IdNotFoundException($"Department.Id => {id}, not found");
        }

        return department;
    }

    public async Task CreateAsync(Department department)
    {
        using var _context = new ApplicationDbContext();

        await _context.AddAsync(department);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Department department)
    {
        using var _context = new ApplicationDbContext();

        try
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartmentExists(department.Id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        using var _context = new ApplicationDbContext();
        if (_context.Departments == null)
        {
            throw new EntityMissingException("Department dbset is missing");
        }
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
        }

        await _context.SaveChangesAsync();
    }

    private bool DepartmentExists(int id)
    {
        using var _context = new ApplicationDbContext();
        return _context.Departments.Any(e => e.Id == id);
    }
}