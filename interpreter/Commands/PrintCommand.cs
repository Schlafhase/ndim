using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class PrintCommand : ICommand
	{
		NdimParser ndim;

        public PrintCommand(NdimParser ndim)
        {
            this.ndim = ndim;
        }

        public void Execute()
        {
            Console.Write(ndim.Stack.Pop());
        }
    }
}
