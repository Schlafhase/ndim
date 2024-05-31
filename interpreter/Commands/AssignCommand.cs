using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class AssignCommand : ICommand
	{
		NdimParser ndim;

		public AssignCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int value = ndim.Stack.Pop();
			ndim.CoordinateSystem.RegisterCommandOrValue(ndim.CoordinateSystem.Pointer.GetRight(), new Value(ndim, value));
		}
	}
}
