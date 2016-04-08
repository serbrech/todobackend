using Akka.Actor;

[assembly: Microsoft.Owin.OwinStartup (typeof(TodoBackend.Startup))]

namespace TodoBackend
{
	using System.Web.Http;
	using Owin;

	public class ManualDependencyInjector
	{
	}

}