using System;

namespace TodoBackend
{

	public interface ICommand { }

	public interface IEvent	{ }

	public class GetAll : ICommand {}

	public class GetOne
	{
		public int Id {
			get;
			set;
		}
	}


	public class CreateList : ICommand { }

	public class ListCreated : IEvent { }


	public class Remove : ICommand { } 

	public class ItemRemoved : IEvent{ }


	public class Add : ICommand { 
		public string Title {
			get;
			set;
		}
	
		public string Id {
			get;
			set;
		}
	}

	public class GetValue{}

	public class ItemAdded { }


	public class SetTitle : ICommand 
	{ 
		public string Title {
			get;
			set;
		}  
	}

	public class TitleSet : IEvent { }


	public class Activate : ICommand { }

	public class ItemActivated : IEvent {}

	 
	public class Complete : ICommand { }

	public class ItemArchived : IEvent { }

}