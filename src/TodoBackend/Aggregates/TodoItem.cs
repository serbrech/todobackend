using System;
using Akka.Actor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBackend
{
	public class TodoItem 
	{
		public TodoItem ()
		{
			
		}
		public int Order { get; set;}
		public bool Completed { get; set; }
		public string Title { get; set; }
		public string id { get; set; }
	}
}

