using Akka.Actor;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace TodoBackend.Controllers
{
    using System.Web.Http;


    public class TodosController : ApiController
    {
		IActorRef _todoList;

		public TodosController ()
		{
			_todoList = Startup.TodoList.Value;
		}

		public async Task<IHttpActionResult> Get()
		{
			var todos = await _todoList.Ask<IEnumerable<TodoItem>>(new GetAll());
			todos = new List<TodoItem>{ new TodoItem(){ Title = "hello"}};
			return this.Ok(todos.ToList());
		}

        public async Task<IHttpActionResult> Get(int id)
        {
			var item = await _todoList.Ask<TodoItem>(new GetOne(){Id = id});
            return this.Ok(item);
        }

		public async Task<IHttpActionResult> Post(TodoItem item)
		{
			if (item == null)
				return this.BadRequest();
			var addedItem = await _todoList.Ask<TodoItem>(new Add (){ Title = item.Title }, TimeSpan.FromSeconds(1));
			return this.Created("url", addedItem);
        }

        public IHttpActionResult Patch(int id, TodoItem patch)
        {
			return this.Ok(new TodoItem { Title = patch.Title, id = id.ToString()});
        }

        public IHttpActionResult Delete()
        {
            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            return this.Ok();
        }

        
    }
}