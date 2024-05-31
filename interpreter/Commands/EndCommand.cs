using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class EndCommand : ICommand
	{
		private NdimParser ndim { get; }

		public EndCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			ndim.Running = false;
		}
	}
}
