using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class PushCommand : ICommand
	{
		NdimParser ndim;
		int value;

		public PushCommand(NdimParser ndim, int value)
		{
			this.ndim = ndim;
			this.value = value;
		}

		public void Execute()
		{
			ndim.Stack.Push(value);
		}
	}
}
