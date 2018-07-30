using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using Supero.TaskList.Domain.Interfaces;
using Supero.TaskList.Service.Interfaces;
using Supero.TaskList.Web.Framework.Model;

namespace Supero.TaskList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var items = _todoItemService.GetAllTodoItems();

            var todoModels = new List<TodoItemDto>();

            foreach (var item in items)
            {
                var userModel = new TodoItemDto();
                userModel.InjectFrom(item);
                todoModels.Add(userModel);
            }

            return Ok(todoModels.AsEnumerable());
            
        }
    }
}