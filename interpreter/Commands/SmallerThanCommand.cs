using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class SmallerThanCommand : ICommand
	{
		NdimParser ndim;

		public SmallerThanCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int a = ndim.Stack.Pop();
			int b = ndim.Stack.Pop();
			if (b < a)
			{
				ndim.Stack.Push(1);
			}
		}
	}
}
