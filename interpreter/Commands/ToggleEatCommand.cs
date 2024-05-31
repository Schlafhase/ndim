using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class ToggleEatCommand : ICommand
	{
		NdimParser ndim;

		public ToggleEatCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			ndim.EatMode = ndim.EatMode ? true : false;
		}
	}
}
