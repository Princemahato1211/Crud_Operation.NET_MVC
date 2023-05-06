using CRUD_OPERATION_2.Data;
using CRUD_OPERATION_2.Data.Services;
using CRUD_OPERATION_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_OPERATION_2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        //display all the data in index page
        public async Task<IActionResult> Index()
        {
            var data =await _service.GetAllAsync();
            return View(data);
        }

        //Create a Data
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("emp_name,state")]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            //var employee1 = new Employee
            //{
            //    emp_name = employee.emp_name,
            //    state = employee.state

            //};
            //_context.Employee_table.Add(employee1);
            await _service.AddAsync(employee);
            return RedirectToAction("Index");
        }

        //  Employee/details
        public async Task<IActionResult> Details(int id) 
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if(employeeDetails == null)
            {
                return View("Not Found");
            }else
            {
                return View(employeeDetails);
            }
        }


        // update the data
        public async Task<IActionResult> Edit(int id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Not Found");
            }
            return View(employeeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("emp_id,emp_name,state")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            await _service.UpdateAsync(id,employee);
            return RedirectToAction(nameof(Index));
        }

        // Delete the data
        public async Task<IActionResult> Delete(int id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Not Found");
            }
            return View(employeeDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);
            if (employeeDetails == null)
            {
                return View("Not Found");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


 