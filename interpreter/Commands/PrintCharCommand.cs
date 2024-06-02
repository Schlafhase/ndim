using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class PrintCharCommand : ICommand
	{
		NdimParser ndim;

		public PrintCharCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int value = ndim.Stack.Pop();
			Console.Write(char.ConvertFromUtf32(value));
		}
	}
}
