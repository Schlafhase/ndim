using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class DuplicateCommand : ICommand
	{
		NdimParser ndim;

		public DuplicateCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int value = ndim.Stack.Pop();
			ndim.Stack.Push(value);
			ndim.Stack.Push(value);
		}
	}
}
