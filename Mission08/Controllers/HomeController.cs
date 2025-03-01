using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08.Models;

namespace Mission08.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext _context;

        public HomeController(TaskContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var tasks = _context.MyTasks
                .Include(x => x.Category)
                .ToList();

            return View("Quadrants", tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("AddTask", new MyTask());
        }

        [HttpPost]
        public IActionResult AddTask(MyTask response)
        {
            if (ModelState.IsValid)
            {
                _context.MyTasks.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }
        
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var taskToEdit = _context.MyTasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(MyTask updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _context.MyTasks
                .Single(x => x.TaskId == id);

            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult DeleteTask(MyTask myTask)
        {
            _context.MyTasks.Remove(myTask);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
