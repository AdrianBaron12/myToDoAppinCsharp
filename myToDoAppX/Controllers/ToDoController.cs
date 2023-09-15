using Microsoft.AspNetCore.Mvc;
using myToDoAppX.Data;
using myToDoAppX.Models;

namespace myToDoAppX.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
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
            if(ModelState.IsValid)
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
            return Ok(new {success=true});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ToDoModel todo = _context.ToDos.Find(id);
            if(todo!=null)
            {
                return View(todo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ToDoModel todo)
        {
            if(ModelState.IsValid)
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
            if(todo!=null)
            {
                return View(todo);
            }
            return RedirectToAction("Index");
        }

        public IActionResult IsChecked(int id)
        {
            ToDoModel todo = _context.ToDos.Find(id);
            if (todo!=null)
            {
                todo.IsDone = !todo.IsDone;
                _context.ToDos.Update(todo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
    }
}
