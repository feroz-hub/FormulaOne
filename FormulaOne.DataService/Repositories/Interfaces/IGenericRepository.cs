namespace FormulaOne.DataService.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(Guid id);
    Task<bool> Add(T value);
    Task<bool> Update(T value);
    Task<bool> Delete(Guid id);
}