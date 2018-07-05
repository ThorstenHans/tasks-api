using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasks.API.Repositories;
using Models = Tasks.API.Models;

namespace Tasks.API.Controllers {
    [Route ("api/[controller]")]
    public class TasksController : Controller {
        private ITasksRepository Repository { get; }

        public TasksController (ITasksRepository repository) {
            Repository = repository;
        }

        [HttpGet]
        public IEnumerable<Models.Task> Get () {
            return Repository.GetAllTasks ();
        }

        // GET api/values/5
        [HttpGet ("{id}", Name = "GetTask")]
        public IActionResult Get (Guid id) {
            var foundTask = Repository.GetTaskById (id);
            if (foundTask == null) return NotFound ();

            return Json (foundTask);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post ([FromBody] Models.Task task) {
            var created = Repository.CreateTask (task);
            return CreatedAtRoute ("GetTask", new { id = created.Id }, created);
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public IActionResult Put (Guid id, [FromBody] Models.Task task) {
            var updated = Repository.UpdateTask (id, task);
            if (updated == null) return NotFound ();
            return Json (updated);
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public IActionResult Delete (Guid id) {
            if (Repository.DeleteTask (id)) return NoContent ();
            return NotFound ();
        }
    }
}
