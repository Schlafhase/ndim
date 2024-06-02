using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndimInterpreter.Commands
{
    public class ChangePointerDirectionCommand : ICommand
    {
        private NdimParser ndim { get; }
        string type;
        int data;
        Random random;

        public ChangePointerDirectionCommand(NdimParser ndim, int data)
        {
            this.data = data;
            this.ndim = ndim;
            random = new();
            type = "set";
        }

        public ChangePointerDirectionCommand(NdimParser ndim)
        {
            this.ndim = ndim;
            random = new();
            type = "random";
        }

        public void Execute()
        {
            switch (type)
            {
                case "set":
                    ndim.CoordinateSystem.Pointer.SetDirection(data); break;
                case "random":
                    int newDirection = random.Next(1, ndim.CoordinateSystem.Dimensions);
                    if (random.Next(1, 2) == 1)
                    {
                        newDirection *= -1;
                    }
                    ndim.CoordinateSystem.Pointer.SetDirection(newDirection);
                    break;
            }
        }
    }
}
