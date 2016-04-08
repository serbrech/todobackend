using System;

namespace TodoBackend
{

	public interface ICommand { }

	public class Remove : ICommand { } 

	public class Add : ICommand { }

	public class SetTitle : ICommand {  }

	public class Activate : ICommand { }

	public class Complete : ICommand { }

}