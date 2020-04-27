using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeLeaveTraining.Contracts;
using EmployeeLeaveTraining.Data;
using EmployeeLeaveTraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveTraining.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        /// <summary>
        /// GET: Index of leave types
        /// </summary>
        /// <returns></returns>        
        public ActionResult Index()
        {
            //Getting the data
            var leaveTypes = _repo.FindAll().ToList();
            //Mapping the retrieved data to the view model and to the repository data
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leaveTypes);
            //Passing the model tot he view
            return View(model);
        }

        /// <summary>
        /// GET: Gets the details about a leave type for the details view
        /// </summary>
        /// <param name="id">The id of the leave type</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }

            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(model);
        }

        /// <summary>
        /// GET: Returning the view model for creation of a new leave type
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Creating the leave type 
        /// </summary>
        /// <param name="model">The data filled in the form</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel model) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                //Map the model to the LeaveType data
                var leaveType = _mapper.Map<LeaveType>(model);
                //Adding the current server time
                leaveType.DateCreated = DateTime.Now;
                //Create entity with the leaveType data
                var isSuccess = _repo.Create(leaveType);

                //If entity was not created add an error to the ModelState
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        /// <summary>
        /// GET: Editing the desired leave type based on id
        /// </summary>
        /// <param name="id">The id of the leave type</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }

            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(model);
        }

        /// <summary>
        /// POST: Editing the leave type according to the changes made in the model
        /// </summary>
        /// <param name="model">The data made in the form</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var leaveType = _mapper.Map<LeaveType>(model);               
                var isSuccess = _repo.Update(leaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
         
        /// <summary>
        /// GET: Deleting the leave type by id
        /// </summary>
        /// <param name="id">The id of the leave type</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var leaveType = _repo.FindById(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(leaveType);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }        
    }
}