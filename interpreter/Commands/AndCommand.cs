using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class AndCommand : ICommand
	{
		NdimParser ndim;

		public AndCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int a = ndim.Stack.Pop();
			int b = ndim.Stack.Pop();
			if (a > 0 && b > 0)
			{
				ndim.Stack.Push(1);
			}
		}
	}
}
