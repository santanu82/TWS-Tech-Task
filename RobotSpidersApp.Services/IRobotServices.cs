using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpidersApp.Services
{
    public interface IRobotServices 
    {
        Tuple<int, int, char> GetRobotFinalCoordinateAndOrientation(Tuple<int, int> robotMaxCoordinates,
            Tuple<int, int, char> RobotInitialCoordinatesAndOrientation, string robotInstruction);
    }
}
