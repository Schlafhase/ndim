using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter
{
	public class Coordinate
	{
		private readonly List<int> vector;

		public Coordinate(List<int> vector)
		{
			this.vector = vector;
		}

		public List<int> GetVector()
		{
			return this.vector.ToList();
		}

		public override bool Equals(object? obj)
		{
			return obj is Coordinate co
				? Enumerable.SequenceEqual(vector, co.vector) 
				: false;
		}

		public override int GetHashCode()
		{
			HashCode hashCode = new();
			foreach(var item in this.vector)
			{
				hashCode.Add(item);
			}
			return hashCode.ToHashCode();
		}
	}
}