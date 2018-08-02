using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using Supero.TaskList.Domain.BusinessExceptions;
using Supero.TaskList.Service.CommandHandlers;
using Supero.TaskList.Service.Commands.TodoItemCommands;
using Supero.TaskList.Service.Queries.TodoItemQueries;
using Supero.TaskList.Service.QueryHandlers;
using Supero.TaskList.Web.Framework.Model;

namespace Supero.TaskList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {

        private readonly TodoItemCommandHandler _todoItemCommandHandler;
        private readonly TodoItemQueryHandler _todoItemQueryHandler;


        public TodoItemController(TodoItemCommandHandler itemCommandHandler, TodoItemQueryHandler todoItemQueryHandler)
        {
            _todoItemCommandHandler = itemCommandHandler;
            _todoItemQueryHandler = todoItemQueryHandler;
        }


        /// <summary>
        /// Retorna todos os To-Do Items.
        /// </summary>
        /// <param name="skip">Parametro para paginação</param>
        /// <param name="top">Parametro para paginação</param>
        /// <returns>Uma coleção de TO-DO Items</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get(int skip = 0, int top = 0)
        {
            var query = new GetAllTodoItemsQuery(skip, top);
            query.Validate();

            if (query.Invalid)
                return BadRequest(query);

            var result = _todoItemQueryHandler.Handle(query);

            var listDto = new List<TodoItemDto>();

            foreach (var item in result)
            {
                var todoItemDto = new TodoItemDto();
                todoItemDto.InjectFrom(item);
                listDto.Add(todoItemDto);
            }

            return Ok(listDto.AsEnumerable());

        }



        /// <summary>
        /// Retorna um objeto especifico To-Do Item.
        /// </summary>
        /// <param name="id">chave unica de identificação.</param>
        /// <returns>Um objeto To-Do Item.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetById(long id)
        {
            try
            {
                var query = new GetTodoItemsById(id);
                query.Validate();

                if (query.Invalid)
                    return BadRequest(query);

                var result = _todoItemQueryHandler.Handle(query);

                var todoItemDto = new TodoItemDto();
                todoItemDto.InjectFrom(result);
            
                return Ok(todoItemDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        /// <summary>
        /// Cria um objeto To-Do Item.
        /// </summary>
        /// <param name="todoItemDto">Conteudo do objeto</param>
        /// <returns>Status ok caso tenha sido criado corretamente.</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult Post([FromBody]TodoItemDto todoItemDto)
        {
            try
            {
                var command = new CreateTodoItemCommand(todoItemDto.Description, todoItemDto.IsCompleted);
                command.Validate();

                if (command.Invalid)
                    return Ok(command);

                _todoItemCommandHandler.Handle(command);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        // PUT: api/Company/5
        /// <summary>
        /// Altera um objeto To-Do Item.
        /// </summary>
        /// <param name="id">chave unica de identificação.</param>
        /// <param name="todoItemDto">Conteudo do objeto</param>
        /// <returns>Status ok caso tenha sido criado corretamente.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(long id, [FromBody]TodoItemDto todoItemDto)
        {
            try
            {
                var command = new ChangeTodoItemCommand(todoItemDto.Description, todoItemDto.IsCompleted);
                command.Id = id;
                command.Validate();

                if (command.Invalid)
                    return BadRequest(command);

                _todoItemCommandHandler.Handle(command);

                return Ok(command);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Deleta um objeto To-Do Item do banco.
        /// </summary>
        /// <param name="id">chave unica de identificação.</param>
        /// <returns>Status ok caso tenha sido criado corretamente.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Delete(long id)
        {
            try
            {

                var command = new DeleteTodoItemCommand(id);
                command.Id = id;

                command.Validate();

                if (command.Invalid)
                    return Ok(command);

                _todoItemCommandHandler.Handle(command);

                return Ok(command);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}