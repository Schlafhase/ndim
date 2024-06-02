using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter
{
	public struct NdimPointer
	{
		public int Direction { get; private set; }
		public Coordinate Position { get; private set; }
		private int dimensions;

		public NdimPointer(int dimensions)
		{
			this.dimensions = dimensions;
			Direction = 1;
			Position = new(Enumerable.Repeat(0, dimensions).ToList());
		}

		public void SetDirection(int dir)
		{
			Direction = dir;
		}

		public void MoveNext()
		{
			int step = Direction < 1 ? -1 : 1;
			List<int> vec = Position.GetVector();
			vec[Math.Abs(Direction)-1] += step;
			Position = new(vec);
		}

		public Coordinate GetLeft()
		{
			List<int> vec = Position.GetVector();
			vec[Math.Abs(Direction) % dimensions] -= 1;
			return new Coordinate(vec);
		}

		public Coordinate GetRight()
		{
			List<int> vec = Position.GetVector();
			vec[Math.Abs(Direction) % dimensions] += 1;
			return new Coordinate(vec);
		}

		public void TurnLeft()
		{
			Direction = -((Math.Abs(Direction) % dimensions) + 1);
		}

		public void TurnRight()
		{
			Direction = (Math.Abs(Direction) % (dimensions)) + 1;
		}
	}
}