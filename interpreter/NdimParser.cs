using ndimInterpreter.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ndimInterpreter
{
	public class NdimParser
	{
		public NdimStack Stack;
		public NdimCoordinateSystem CoordinateSystem;
		public int Dimensions { get; private set; }
		Regex validateNdimCodeRegex;
		Regex whiteSpaceRegex;
		Regex changePointerDirectionCommandRegex;
		Regex pushCommandRegex;
		Regex noParamInstructionRegex;
		Regex ifCommandRegex;
		Regex commentRegex;
		public bool Running;
		public bool EatMode = false;
		public int Jump = -1;

		public NdimParser()
		{
			validateNdimCodeRegex = new(@"^\s*((-?\d+|\?|jump)|(#\d|pop|swap|duplicate|\+|-|\*|/|\^|&|\||!|<|>)|if\s+\d+|(assignHere|assign|toggleEat|input|printChar|print)|end) *(<)([\d, -]+)(>);");
			commentRegex = new(@"^//.*");
			changePointerDirectionCommandRegex = new(@"^\s*((-?\d+)|\?)");
			noParamInstructionRegex = new(@"^\s*(duplicate|jump|pop|swap|\+|-|\*|\/|\^|\<\>|&|\||!|input|assign|assignHere|toggleEat|printChar|print|end)");
			pushCommandRegex = new(@"^\s*(#)(\d)");
			ifCommandRegex = new(@"^\s*if\s+(\d+)");
			whiteSpaceRegex = new(@"\s+");
		}

		public void RunNdimFromFile(string filepath)
		{
			try
			{
				using StreamReader sr = new(filepath);
				string? line = sr.ReadLine();
				if (line is null)
				{
					return;
				}
				Match ndimInitializeMatch = Regex.Match(line, @"^(\d+)dim");
				if (!ndimInitializeMatch.Success)
				{
					throw new SyntaxErrorException("The program must contain a valid start matching the regex ^(\\d+)dim;");
				}
				Dimensions = int.Parse(ndimInitializeMatch.Groups[1].Value);
				Stack = new NdimStack();
				CoordinateSystem = new NdimCoordinateSystem(Dimensions, new NdimPointer(Dimensions));
				if (Dimensions <= 0)
				{
					throw new ArgumentException("Dimension must be at least 1.");
				}
				line = sr.ReadLine();

				while (line is not null)
				{
					registerCommand(line);
					if (EatMode)
					{
						CoordinateSystem.UnregisterCommandOrValue(CoordinateSystem.Pointer.Position);
					}
					line = sr.ReadLine();
				}
			}
			catch
			{
				throw;
			}
			Running = true;
			while (Running)
			{
				CoordinateSystem.StepNext();
				Jump -= 1;
			}
		}

		private void registerCommand(string command)
		{
			Match commentMatch = commentRegex.Match(command);
			if (commentMatch.Success)
			{
				return;
			}
			Match commandMatch = validateNdimCodeRegex.Match(command);
			if (!commandMatch.Success)
			{
				throw new SyntaxErrorException("Invalid Syntax or unknown Command");
			}
			string instruction = commandMatch.Groups[1].Value;
			List<int> coord = whiteSpaceRegex.Replace(commandMatch.Groups[6].Value, "").Split(",").Select(x => int.Parse(x)).ToList();
			if (coord.Count != Dimensions)
			{
				throw new SyntaxErrorException($"Vector was not {Dimensions} dimensional");
			}

			ICommand cmd;
			Match changePointerDirectionCommandMatch = changePointerDirectionCommandRegex.Match(instruction);
			Match pushCommandMatch = pushCommandRegex.Match(instruction);
			Match ifCommandMach = ifCommandRegex.Match(instruction);
			Match noParamInstructionMatch = noParamInstructionRegex.Match(instruction);
			if (changePointerDirectionCommandMatch.Success)
			{
				if (changePointerDirectionCommandMatch.Value == "?")
				{
					cmd = new ChangePointerDirectionCommand(this);
				}
				else
				{
					int direction = int.Parse(changePointerDirectionCommandMatch.Value);
					if (Math.Abs(direction) > Dimensions)
					{
						throw new SyntaxErrorException($"Direction must be an axis in a {Dimensions} dimensional coordinate system");
					}
					cmd = new ChangePointerDirectionCommand(this, direction);
				}
			}
			else if (pushCommandMatch.Success)
			{
				cmd = new PushCommand(this, int.Parse(pushCommandMatch.Groups[2].Value));
			}
			else if (ifCommandMach.Success)
			{
				cmd = new IfCommand(this, int.Parse(ifCommandMach.Groups[1].Value));
			}
			else if (noParamInstructionMatch.Success)
			{
				if (noParamInstructionMatch.Value == "end")
				{
					cmd = new EndCommand(this);
				}
				else if (noParamInstructionMatch.Value == "duplicate")
				{
					cmd = new DuplicateCommand(this);
				}
				else if (noParamInstructionMatch.Value == "assign")
				{
					cmd = new AssignCommand(this);
				}
				else if (noParamInstructionMatch.Value == "+")
				{
					cmd = new PlusCommand(this);
				}
				else if (noParamInstructionMatch.Value == "-")
				{
					cmd = new MinusCommand(this);
				}
				else if (noParamInstructionMatch.Value == "*")
				{
					cmd = new MultiplyCommand(this);
				}
				else if (noParamInstructionMatch.Value == "/")
				{
					cmd = new DivideCommand(this);
				}
				else if (noParamInstructionMatch.Value == "^")
				{
					cmd = new PowerCommand(this);
				}
				else if (noParamInstructionMatch.Value == "<")
				{
					cmd = new SmallerThanCommand(this);
				}
				else if (noParamInstructionMatch.Value == ">")
				{
					cmd = new GreaterThanCommand(this);
				}
				else if (noParamInstructionMatch.Value == "&")
				{
					cmd = new AndCommand(this);
				}
				else if (noParamInstructionMatch.Value == "|")
				{
					cmd = new OrCommand(this);
				}
				else if (noParamInstructionMatch.Value == "!")
				{
					cmd = new NotCommand(this);
				}
				else if (noParamInstructionMatch.Value == "printChar")
				{
					cmd = new PrintCharCommand(this);
				}
				else if (noParamInstructionMatch.Value == "assignHere")
				{
					cmd = new AssignHereCommand(this);
				}
				else if (noParamInstructionMatch.Value == "print")
				{
					cmd = new PrintCommand(this);
				}
				else if (noParamInstructionMatch.Value == "input")
				{
					cmd = new InputCommand(this);
				}
				else if (noParamInstructionMatch.Value == "toggleEat")
				{
					cmd = new ToggleEatCommand(this);
				}
				else if (noParamInstructionMatch.Value == "jump")
				{
					cmd = new JumpCommand(this);
				}
				else if (noParamInstructionMatch.Value == "pop")
				{
					cmd = new PopCommand(this);
				}
				else if (noParamInstructionMatch.Value == "swap")
				{
					cmd = new SwapCommand(this);
				}
				else
				{
					throw new SyntaxErrorException("Unrecognized parameterless command");
				}
			}
			else
			{
				throw new SyntaxErrorException("Invalid command");
			}
			CoordinateSystem.RegisterCommandOrValue(new Coordinate(coord), cmd);
		}
	}
}
