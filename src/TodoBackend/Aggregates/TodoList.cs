using System;
using Akka.Actor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBackend
{
	public class TodoList : ReceiveActor{

		public TodoList ()
		{
			ReceiveAsync<GetAll>(GetAllItems);
			ReceiveAsync<Add> (AddNew);
			ReceiveAsync<GetOne> (GetOne);
		}

		async Task AddNew(Add addItem){
			var item = Context.ActorOf<ItemActor> (name : addItem.Id);
			item.Tell(new SetTitle (){ Title = addItem.Title });
			var ask = await item.Ask<TodoItem>(new GetOne (){ Id = int.Parse(addItem.Id) });
			this.Sender.Tell (ask);
		}

		async Task GetAllItems(GetAll msg)
		{	
			var actorchildren = Context.GetChildren();
			IEnumerable<Task<TodoItem>> taskOfItem = actorchildren.Select(itemActor => GetItem(itemActor));
			await Task.WhenAll(taskOfItem).ContinueWith(r => r.PipeTo(this.Sender));
		}

		async Task GetOne(GetOne msg){
			var itemactor = Context.Child (msg.Id.ToString());
			var ask = await GetItem (itemactor);
			this.Sender.Tell(ask);
		}

		static Task<TodoItem> GetItem (IActorRef itemactor)
		{
			var ask = itemactor.Ask<TodoItem> (new GetValue ());
			ask.Wait ();
			return ask;
		}

		public void Apply(dynamic @event){
			Apply (@event);
		}

		private void Apply(ItemAdded added){
			
		}
	}

}
