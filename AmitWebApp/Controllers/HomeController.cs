using AmitWebApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MyWebApp.Models;
using System.Diagnostics;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment env;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment env, ILogger<HomeController> logger)
        {
            
            this._employeeRepository=employeeRepository;
            this.env = env;
            _logger = logger;
        }
        //public string Index()
        //{
        //    return _employeeRepository.GetEmployee(1001).Name;
        //}
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is Index!");
            List<Employee> employees=_employeeRepository.GetAllEmployee();
            ViewBag.Title = "All Employees List";
            ViewBag.Employees = employees;
            
            return View(employees);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult EmpDetails(int id)
        {
            //throw new Exception("Error in Details View");
            if (id==null)
            {
                return NotFound();
            }
            EmployeeViewModel model = new EmployeeViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id),
             
                PageData=new PageData { PageTitle="Employee Details", PageDescription="Details of Employee" }
            };
            if(model.Employee==null)
            {
                return View("notFound", id);
            }

            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PageTitle = "Create Employee";
            ViewBag.state = await _employeeRepository.statelist();
            return View();
        }
        public async Task<IActionResult> FetchDistrict( int id)
        {
            var dis = await _employeeRepository.District(id);
            return Json(dis);
        }

        public async Task<IActionResult> FetchCity(int id)
        {
            var dis = await _employeeRepository.Cities(id);
            return Json(dis);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqeFileName = null;

                if (model.Photo != null)
                {
                    string upload = Path.Combine(env.WebRootPath, "Images");
                    uniqeFileName = Guid.NewGuid().ToString() + "-" + model.Photo.FileName;
                    string photopath = Path.Combine(upload, uniqeFileName);
                    model.Photo.CopyTo(new FileStream(photopath, FileMode.Create));
                }
                Employee employee1=new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department=model.Department,
                    HireDate=model.HireDate,
                    Salary=model.Salary,
                    AddOn=model.AddOn,
                    UpdateOn=model.UpdateOn,
                    RecStatus=model.RecStatus,
                    PhotoPath = uniqeFileName,
                    Job = model.Job,
                };


                var result =  _employeeRepository.AddEmployee(employee1);
                return RedirectToAction("Index");
            }

            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _employeeRepository.GetEmployee(id);
            ViewBag.PageTitle = "Delete Employee";
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(int? id)

        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var empid = _employeeRepository.GetAllEmployee();
            var Delid = empid.FirstOrDefault(x=>x.Id==id);
            if(Delid!= null)
            {
                _employeeRepository.DeleteEmployee(Delid.Id);
                return RedirectToAction("Index");
            }
            ViewBag.PageTitle = "Delete Employee";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var emp = _employeeRepository.GetEmployee(id);

            ViewBag.PageTitle = "Update Employee";
            return View(emp);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var emp = _employeeRepository.GetEmployee(employee.Id);
                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Email=employee.Email;
                    emp.Department= employee.Department;


                }
                _employeeRepository.UpdateEmployee(emp);

                return RedirectToAction("Index");
            }
            return View();

            
            
            
        }
        public IActionResult AllEmpDetails()
        {
            List<Employee> employees = _employeeRepository.GetAllEmployee();
            ViewBag.Title = "All Employees List";
            ViewBag.Employees = employees;
            

            return View(employees);
        }
        public IActionResult GalleryUpload()
        {
            ViewBag.Title = "Upload Gallery";
            return View();
        }
        [HttpPost]
        public IActionResult GalleryUpload(Gallery gallery)
        {
            if(ModelState.IsValid)
            {
                string uniquefilename = null;
                if(gallery.Photos!=null && gallery.Photos.Count>0)
                {
                    foreach(IFormFile photo in gallery.Photos)
                    {
                        string uploadfolder = Path.Combine(env.WebRootPath, "Images");
                        uniquefilename=Guid.NewGuid().ToString()+"_"+photo.FileName;
                        string filepath=Path.Combine(uploadfolder, uniquefilename);
                        photo.CopyTo(new FileStream(filepath, FileMode.Create));
                    }
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}