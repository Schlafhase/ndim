using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	internal class PopCommand : ICommand
	{
		NdimParser ndim;

		public PopCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			ndim.Stack.Pop();
		}
	}
}
