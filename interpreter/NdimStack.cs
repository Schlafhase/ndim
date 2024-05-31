using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter
{
	public class NdimStack
	{
		private int a { get; set; }
		private int b { get; set; }

		public NdimStack()
		{
			a = 0;
			b = 0;
		}

		public void Push(int value)
		{
			b = a;
			a = value;
		}

		public int Pop()
		{
			int temp = a;
			a = b;
			b = 0;
			return temp;
		}

		public void Swap()
		{
			var temp = a;
			a = b;
			b = temp;
		}

		public void duplicate()
		{
			b = a;
		}
	}
}
