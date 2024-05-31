﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
	public class MinusCommand: ICommand
	{
		NdimParser ndim;

		public MinusCommand(NdimParser ndim)
		{
			this.ndim = ndim;
		}

		public void Execute()
		{
			int a = ndim.Stack.Pop();
			int b = ndim.Stack.Pop();
			ndim.Stack.Push(b-a);
		}
	}
}
