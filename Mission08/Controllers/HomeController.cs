using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08.Models;
using Microsoft.EntityFrameworkCore;


namespace Mission08.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var tasks = _repo.TasksQueryable
                .Include(x => x.Category)
                .ToList();

            return View("Quadrants", tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();

            return View("AddTask", new MyTask());
        }

        [HttpPost]
        public IActionResult AddTask(MyTask response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
                _repo.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();
                return View(response);
            }
        
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var taskToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(MyTask updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult DeleteTask(MyTask myTask)
        {
            _repo.Tasks.Remove(myTask);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
