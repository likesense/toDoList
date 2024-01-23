using Microsoft.AspNetCore.Mvc;
using toDoList.Domain.ViewModels.Task;


namespace toDoList.Controllers
{
    public class TaskController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            return Ok();
        }
    }
}