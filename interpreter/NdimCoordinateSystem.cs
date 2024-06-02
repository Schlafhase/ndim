using ndimInterpreter.Commands;
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
			if (commands.ContainsKey(coord) && command is not Value)
			{
				throw new ArgumentException($"There can only be one command at each coordinate. Coordinate <{coord}> was already occupied.");
			}
			commands[coord] = command;
		}

		public void UnregisterCommandOrValue(Coordinate coord)
		{
			commands.Remove(coord);
		}

		public void StepNext(bool jump)
		{
			ICommand command;
			try
			{
				if (!jump)
				{
					command = commands[Pointer.Position];
					command.Execute();
				}
			}
			catch (KeyNotFoundException) {}
			finally
			{
				Pointer.MoveNext();
			}
		}
	}
}
