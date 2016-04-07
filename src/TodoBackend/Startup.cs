[assembly: Microsoft.Owin.OwinStartup(typeof(TodoBackend.Startup))]

namespace TodoBackend
{
    using System.Web.Http;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.Routes.MapHttpRoute("api", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            app.UseWebApi(httpConfiguration);
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}