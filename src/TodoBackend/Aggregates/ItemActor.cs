using System;
using Akka.Actor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBackend
{

	public class ItemActor : ReceiveActor
	{
		private TodoItem _item;
		public ItemActor ()
		{
			Receive<ItemAdded>(added => {_item = new TodoItem();});
			Receive<GetValue> (msg => this.Sender.Tell (_item));
			Receive<SetTitle> (msg => _item.title = msg.Title);
			Receive<Complete> (msg => _item.completed = true);
		}
	}
	
}
