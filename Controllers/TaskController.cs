using Microsoft.AspNetCore.Mvc;
using toDoList.Domain.ViewModels.Task;
using toDoList.Service.Interfaces;

//without logic on open source
//I'll try to use business logic
namespace toDoList.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            //return base respons with his own status 
            var response = await _taskService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK) 
            {
                return Ok(new{description = response.Description});
            }
            return BadRequest(new { description = response.Description });
        }
    }
}