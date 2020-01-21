using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Models;
using AutoMapper;
using Application.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private static Guid FirstGuid = Guid.NewGuid();
        private static ICollection<Todo> Todos { get;set; } = new List<Todo>
        {
            new Todo
            {
                Id = FirstGuid,
                CreatedAt = DateTime.UtcNow,
                DisplayName = "Todo task test",
                Content = "Todo task test",
                IsDone = true,
                UpdatedAt = DateTime.UtcNow.Add(
                    new TimeSpan(hours:0, minutes: 10,seconds:35))
            }
        };

        private readonly ILogger<TodoController> _logger;
        private readonly IMapper _mapper;

        public TodoController(
            ILogger<TodoController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Debug.WriteLine(FirstGuid);
            try
            {
                var guid = Guid.Parse(id);
                var response = Todos.First(todo => todo.Id.Equals(guid));
                if (response != null)
                    return Ok(_mapper.Map<TodoResponse>(response));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] TodoRequest req)
        {
            try 
            {
                var model = _mapper.Map<Todo>(req);
                model.Id = Guid.NewGuid();
                model.CreatedAt = DateTime.UtcNow;
                Todos.Add(model);
                return Created("", _mapper.Map<TodoResponse>(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] TodoRequest req)
        {
            try
            {
                var guid = Guid.Parse(req.Id);
                var model = Todos.First(todo => todo.Id.Equals(guid));
                Todos.Remove(model);
                if (model != null)
                {
                    model.UpdatedAt = DateTime.UtcNow;
                    model.DisplayName = req.DisplayName;
                    model.Content = req.Content;
                    model.IsDone = req.IsDone;
                    Todos.Add(model);
                    return Ok(_mapper.Map<TodoResponse>(model));
                }
                return BadRequest();
            }
            catch( Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try 
            {
                var guid = Guid.Parse(id);
                var model = Todos.First(todo => todo.Id.Equals(guid));
                if (model != null)
                {
                    Todos.Remove(model);
                    return Ok(true);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
