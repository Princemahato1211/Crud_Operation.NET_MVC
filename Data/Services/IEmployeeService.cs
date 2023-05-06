using CRUD_OPERATION_2.Models;

namespace CRUD_OPERATION_2.Data.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee>  GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task<Employee> UpdateAsync(int id, Employee newemployee);
        Task DeleteAsync(int id);
    }
}

