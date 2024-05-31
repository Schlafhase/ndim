using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class NotCommand : ICommand
	{
		NdimParser ndim;

		public NotCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int a = ndim.Stack.Pop();
			if (a > 0)
			{
				ndim.Stack.Push(0);
			}
			else
			{
				ndim.Stack.Push(1);
			}
		}
	}
}
