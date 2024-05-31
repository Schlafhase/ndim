using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class InputCommand : ICommand
	{
		NdimParser ndim;

		public InputCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int value;
			try
			{
				value = int.Parse(Console.ReadLine()!);
			}
			catch
			{
				throw new ArgumentException("Input must be an Integer");
			}
			ndim.Stack.Push(value);
		}
	}
}
