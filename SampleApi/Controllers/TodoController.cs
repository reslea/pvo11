using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        static List<TodoModel> TodoModels = new List<TodoModel>()
        {
            new () { Id = 1, Title = "First"  },
            new () { Id = 2, Title = "Second"  },
            new () { Id = 3, Title = "Third"  },
            new () { Id = 4, Title = "Fourth"  },
        };
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<TodoModel> GetAllTodos()
        {
            _logger.LogInformation("all todos");
            return TodoModels;
        }

        [HttpGet("{todoId}")]
        [ProducesResponseType(typeof(TodoModel), 200), ProducesResponseType(404)]
        public IActionResult GetOne(int todoId)
        {
            var lang = HttpContext.Session.GetString("lang");

            //return TodoModels.FirstOrDefault(x => x.Id == todoId) switch
            //{
            //    TodoModel todo => Ok(todo),
            //    null => NotFound(),
            //};

            TodoModel? todo = TodoModels.FirstOrDefault(x => x.Id == todoId);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpDelete("{todoId}")]
        public void Remove(int todoId)
        {
            var toDelete = TodoModels.FirstOrDefault(x => x.Id == todoId);
            if (toDelete != null)
            {
                TodoModels.Remove(toDelete);
            }
        }
    }
}
