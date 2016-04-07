namespace TodoBackend.Controllers
{
    using System.Web.Http;

    public class TodosController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok(new TodoItem[0]);
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(new TodoItem());
        }

        public IHttpActionResult Post(TodoItem item)
        {
            return this.Created("url", item);
        }

        public IHttpActionResult Patch(int id, TodoItem patch)
        {
            return this.Ok(new TodoItem());
        }

        public IHttpActionResult Delete()
        {
            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            return this.Ok();
        }

        public class TodoItem { }
    }
}