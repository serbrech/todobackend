using Akka.Actor;
using System.Web.Http.Dependencies;
using System.Collections.Generic;
using System;
using TodoBackend.Controllers;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;[assembly: Microsoft.Owin.OwinStartup(typeof(TodoBackend.Startup))]

namespace TodoBackend
{
    using System.Web.Http;
    using Owin;
	using AppFunc = Func<IDictionary<string, object>, Task>; 

    public class Startup
    {
		public static Lazy<ActorSystem> Actors = new Lazy<ActorSystem>(()=>ActorSystem.Create("TodoList"));
		public static Lazy<IActorRef> TodoList = new Lazy<IActorRef>(()=>Actors.Value.ActorOf<TodoList>(name : "main"));

        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            httpConfiguration.MapHttpAttributeRoutes();
			httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver ();
            httpConfiguration.Routes.MapHttpRoute("api", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            app.UseWebApi(httpConfiguration);
            app.UseDefaultFiles();
            app.UseStaticFiles();

        }
    }
}