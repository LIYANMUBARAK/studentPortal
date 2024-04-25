using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentsController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Maths = viewModel.Maths,
                Science = viewModel.Science,
                Arts = viewModel.Arts,
                Total = viewModel.Maths + viewModel.Science + viewModel.Arts
            };


            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();


            TempData["message"] = "Student registration successful";


          

            

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            var students = await dbContext.Students
                .OrderByDescending(s => s.Total) // Sort students by Total marks in descending order
                .ToListAsync();

            return View(students);
        }
    }
}
