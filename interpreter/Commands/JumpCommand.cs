using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class JumpCommand : ICommand
	{
		NdimParser ndim;

		public JumpCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			ndim.Jump = 1;
		}
	}
}
