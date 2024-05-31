using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class SwapCommand : ICommand
	{
		NdimParser ndim;

		public SwapCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			ndim.Stack.Swap();
		}
	}
}
