
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Models;
using System.Linq;
using StudentInformationSystem.Data;

namespace StudentInformationSystem.Controllers
{
    public class StudentController : Controller
    {
        // Step 1: Student List
        // Step 2: Display Student List
        public IActionResult Index(string? searchString)
        {
            var students = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                students = students.Where(s =>
                    s.Name.Contains(searchString));
            }

            ViewBag.CurrentFilter = searchString;

            return View(students.ToList());
        }

        // Step 3: Open Add Student Form
        public IActionResult Create()
        {
            return View();
        }

        // Step 4: Receive New Student Data
       
        [HttpPost]
        public IActionResult Create(Student student)
        {
            // Step 1: Check validation
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            // Step 2: Add student to database
            _context.Students.Add(student);

            // Step 3: Save changes
            _context.SaveChanges();

            // Step 4: Redirect to Student List
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Student? student = _context.Students
                .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
      
        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            // Step 1: Check validation
            if (!ModelState.IsValid)
            {
                return View(updatedStudent);
            }

            // Step 2: Find student in database
            Student? student = _context.Students
                .FirstOrDefault(s => s.StudentId == updatedStudent.StudentId);

            if (student == null)
            {
                return NotFound();
            }

            // Step 3: Update student details
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Gender = updatedStudent.Gender;
            student.Email = updatedStudent.Email;
            student.Class = updatedStudent.Class;
            student.Address = updatedStudent.Address;

            // Step 4: Save changes
            _context.SaveChanges();

            // Step 5: Return to Student List
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Student? student = _context.Students
                .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        public IActionResult TestConnection()
        {
            bool isConnected = _context.Database.CanConnect();

            if (isConnected)
            {
                return Content("Database Connected Successfully!");
            }

            return Content("Database Connection Failed!");
        }
    }
}