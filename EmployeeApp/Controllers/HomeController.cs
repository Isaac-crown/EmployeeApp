using EmployeeApp.Models;
using EmployeeApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index1()
        {
            return View();
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            //throw new Exception("Error in Details View");
            Employee employee = _employeeRepository.GetEmployee(id.Value);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EditViewModel editViewModel = new EditViewModel
            {
                Id = employee.Id,
                NameofProduct = employee.NameofProducts,
                Description = employee.Description,
                Department = employee.Department,
                ExistingPhoto = employee.PhotoPath
            };
            return View(editViewModel);
        }

        [HttpPost]
        
        public IActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.NameofProducts = model.NameofProduct;
                employee.Description = model.Description;
                employee.Department = model.Department;

             
                if(model.Photo != null)
                {

                    if(model.ExistingPhoto != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhoto
                            );
                        System.IO.File.Delete(filePath);
                    }


                    employee.PhotoPath = ProcessUploadFile(model);

                }
                _employeeRepository.Update(employee);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadFile(EmployeeViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null )
            {
               
                
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Photo.CopyTo(fileStream);
                    }
                

            }

            return uniqueFileName;
        }

        [HttpPost]
        
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);
               
                Employee newEmployee = new Employee
                {
                    NameofProducts = model.NameofProduct,
                    Description = model.Description,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }

    }

