using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpidersApp.Services
{
    public interface ICoordinateServices
    {
        int RobotFinalCoordinatesWhenInstructionIsM(char robotInitialOrientation, int robotInitialXCoordinate,
            ref int robotInitialYCoordinate);
    }
}
