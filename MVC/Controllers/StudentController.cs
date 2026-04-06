using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            ViewBag.Message = $"Xin chào {student.FullName} - Mã SV: {student.StudentCode}";
            return View(student);
        }
    }
}
