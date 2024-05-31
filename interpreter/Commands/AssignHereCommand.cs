using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class AssignHereCommand : ICommand
	{
		NdimParser ndim;

		public AssignHereCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int value = ndim.Stack.Pop();
			ndim.CoordinateSystem.RegisterCommandOrValue(ndim.CoordinateSystem.Pointer.Position, new Value(ndim, value));
		}
	}
}
