using Microsoft.AspNetCore.Mvc;
using myToDoAppX.Data;
using myToDoAppX.Models;
using System.Diagnostics;

namespace myToDoAppX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoDbContext _context;


        public HomeController(ILogger<HomeController> logger, ToDoDbContext context)
        {
            _logger = logger;
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View(_context.ToDos.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(ToDoModel toDo)
        {
            if (ModelState.IsValid)
            {
                toDo.Date = DateTime.Now;
                _context.ToDos.Add(toDo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDo);
        }


        public IActionResult Delete(int id)
        {
            ToDoModel todo = _context.ToDos.Find(id);
            if (todo != null)
            {
                _context.ToDos.Remove(todo);
                _context.SaveChanges();
            }
            return Ok(new { success = true });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ToDoModel todo = _context.ToDos.Find(id);
            if (todo != null)
            {
                return View(todo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ToDoModel todo)
        {
            if (ModelState.IsValid)
            {
                _context.ToDos.Update(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        public IActionResult Details(int id)
        {
            ToDoModel todo = _context.ToDos.Find(id);
            if (todo != null)
            {
                return View(todo);
            }
            return RedirectToAction("Index");
        }

        public IActionResult IsChecked(int id)
        {
            ToDoModel todo = _context.ToDos.Find(id);
            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;
                _context.ToDos.Update(todo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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