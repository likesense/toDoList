using Microsoft.AspNetCore.Mvc;


namespace toDoList.Controllers
{
    public class TaskController: Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}