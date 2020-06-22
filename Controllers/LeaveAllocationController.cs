using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeLeaveTraining.Contracts;
using EmployeeLeaveTraining.Data;
using EmployeeLeaveTraining.Data.Migrations;
using EmployeeLeaveTraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveTraining.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveAllocationController(ILeaveTypeRepository typeRepo, ILeaveAllocationRepository allocationRepo, IMapper mapper, UserManager<Employee> userManager)
        {
            _leaveTypeRepo = typeRepo;
            _leaveAllocationRepo = allocationRepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <summary>
        /// GET: Index of leave allocations
        /// </summary>
        /// <returns></returns>        
        public IActionResult Index()
        {
            //Getting the leave types data
            var leaveTypes = _leaveTypeRepo.FindAll().ToList();
            //Mapping the retrieved leave types data to the view model and to the repository data
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leaveTypes);

            var model = new CreateLeaveAllocationViewModel
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };

            //Passing the model tot he view
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var leaveAllocation = _leaveAllocationRepo.FindById(id);
            var model = _mapper.Map<EditLeaveAllocationViewModel>(leaveAllocation); 
            return View(model);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditLeaveAllocationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var record = _leaveAllocationRepo.FindById(model.Id);
                record.NumberOfDays = model.NumberOfDays;  
                var isSuccess = _leaveAllocationRepo.Update(record);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while saving!");
                    return View(model);
                }
                
                return RedirectToAction(nameof(Details), new { id = model.EmployeeId} );
            }
            catch
            {
                return View(model);
            }
        }

        /// <summary>
        /// GET: Allocating all the leave types for all the employees for the specific period
        /// </summary>
        /// <param name="id">The id of the leave type</param>
        /// <returns></returns>
        public ActionResult SetLeave(int id)
        {
            var leaveType = _leaveTypeRepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;

            foreach (var employee in employees)
            {
                //If the leave type was already allocated to the employee continue with the next iteration
                if (_leaveAllocationRepo.CheckAllocation(id, employee.Id))                
                    continue;               

                //If the leave type was not allocated to the employee create the allocation view model
                var allocation = new LeaveAllocationViewModel
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = employee.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };

                //Map the allocation view model to the allocation repository data
                var leaveAllocation = _mapper.Map<LeaveAllocation>(allocation);

                //Create the leave allocations entry in the database
                _leaveAllocationRepo.Create(leaveAllocation);
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET: Retrieving the list of employees
        /// </summary>
        /// <returns></returns>
        public ActionResult ListEmployees()
        {
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            var model = _mapper.Map<List<EmployeeViewModel>>(employees);

            return View(model);
        }

        /// <summary>
        /// GET: Retrieving the leave allocations for an employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var employee = _mapper.Map<EmployeeViewModel>(_userManager.FindByIdAsync(id).Result); 
            var allocations = _mapper.Map<List<LeaveAllocationViewModel>>(_leaveAllocationRepo.GetLeaveAllocations(id));           

            var model = new ViewAllocationsViewModel
            {
                Employee = employee,
                LeaveAllocations = allocations
            };

            return View(model);
        }
    }
}
