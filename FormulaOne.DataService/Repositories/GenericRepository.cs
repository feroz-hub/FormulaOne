using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class GenericRepository<T>(AppDbContext dbContext, ILogger logger) :IGenericRepository<T> where T:class
{
    protected AppDbContext _dbContext = dbContext;
    protected DbSet<T> _dbSet = dbContext.Set<T>();
    protected readonly ILogger _logger = logger;
    
    public virtual async Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T value)
    {
        await _dbSet.AddAsync(value);
        return true;
    }

    public virtual async Task<bool> Update(T value)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}