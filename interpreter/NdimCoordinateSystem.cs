using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter
{
	public class NdimCoordinateSystem
	{
		public NdimPointer Pointer;
		Dictionary<Coordinate, ICommand> commands;
		public readonly int Dimensions;

		public NdimCoordinateSystem(int dimensions, NdimPointer pointer)
		{
			this.Dimensions = dimensions;
			this.Pointer = pointer;
			commands = [];
		}

		public void RegisterCommandOrValue(Coordinate coord, ICommand command)
		{
			commands[coord] = command;
		}

		public void UnregisterCommandOrValue(Coordinate coord)
		{
			commands.Remove(coord);
		}

		public void StepNext()
		{
			ICommand command;
			try
			{
				command = commands[Pointer.Position];
				command.Execute();
			}
			catch (KeyNotFoundException) {}
			finally
			{
				Pointer.MoveNext();
			}
		}
	}
}
