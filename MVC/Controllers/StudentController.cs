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
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Xin chào {student.FullName} - Mã SV: {student.StudentCode}";
            }
            else
            {
                ViewBag.Message = "Dữ liệu không hợp lệ!";
            }

            return View(student);
        }

        // Trang NotFound
        public IActionResult NotFoundPage()
        {
            return View("NotFound");
        }

        // Ví dụ kiểm tra dữ liệu
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("NotFoundPage");
            }

            return View();
        }
    }
}