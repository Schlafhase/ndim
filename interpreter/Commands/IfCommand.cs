using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class IfCommand : ICommand
	{
		NdimParser ndim;
		int value;

		public IfCommand(NdimParser ndim, int value)
		{
			this.ndim = ndim;
			this.value = value;
		}

		public void Execute()
		{
			if (ndim.Stack.Pop() == value)
			{
				ndim.CoordinateSystem.Pointer.TurnRight();
			}
			else
			{
				ndim.CoordinateSystem.Pointer.TurnLeft();
			}
		}
	}
}
