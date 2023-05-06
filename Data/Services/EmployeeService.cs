using CRUD_OPERATION_2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUD_OPERATION_2.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await _context.Employee_table.ToListAsync();
            return result;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var result = await _context.Employee_table.FirstOrDefaultAsync(n => n.emp_id == id);
            return result;
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employee_table.AddAsync(employee);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Employee_table.FirstOrDefaultAsync(n => n.emp_id == id);
            _context.Employee_table.Remove(result);
            await _context.SaveChangesAsync();

        }

        public async Task<Employee> UpdateAsync(int id, Employee newemployee)
        {
            _context.Update(newemployee);
            await _context.SaveChangesAsync();
            return newemployee;
        }
    }
}


