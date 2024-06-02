using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class GreaterThanCommand : ICommand
	{
		NdimParser ndim;

		public GreaterThanCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int a = ndim.Stack.Pop();
			int b = ndim.Stack.Pop();
			if (b > a)
			{
				ndim.Stack.Push(1);
			}
		}
	}
}
