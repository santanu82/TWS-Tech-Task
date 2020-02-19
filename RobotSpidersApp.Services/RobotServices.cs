using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpidersApp.Services
{
    public enum RobotOrientation
    {
        E,
        N,
        W,
        S
    }
    /// <summary>
    /// This is main classs which is used both for running and testing the app
    /// </summary>
    /// <seealso cref="RobotSpidersApp.Services.IRobotServices" />
    /// <seealso cref="RobotSpidersApp.Services.ICoordinateServices" />
    /// <seealso cref="RobotSpidersApp.Services.IOrientationServices" />
    public class RobotServices:IRobotServices, ICoordinateServices, IOrientationServices
    {


        /// <summary>
        /// Gets the robot final coordinate and orientation.
        /// </summary>
        /// <param name="robotMaxCoordinates">The robot maximum coordinates.</param>
        /// <param name="robotInitialCoordinatesAndOrientation">The robot initial coordinates and orientation.</param>
        /// <param name="robotInstruction">The robot instruction.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Invalid character in the instruction! Sorry we can't  process it
        /// or
        /// Sorry :( Spider can not go beyound the allowed max coordinates
        /// </exception>
        public Tuple<int, int, char> GetRobotFinalCoordinateAndOrientation(Tuple<int, int> robotMaxCoordinates, 
            Tuple<int, int, char> robotInitialCoordinatesAndOrientation, string robotInstruction)
        {

            var robotMaxXCoordinate = robotMaxCoordinates.Item1;
            var robotMaxYCoordinate = robotMaxCoordinates.Item2;
            var robotInitialXCoordinate = robotInitialCoordinatesAndOrientation.Item1;
            var robotInitialYCoordinate = robotInitialCoordinatesAndOrientation.Item2;
            var robotInitialOrientation = robotInitialCoordinatesAndOrientation.Item3;
            //remove all white space characters from the robot instruction
           foreach (char c in new string(robotInstruction.Where(c => !char.IsWhiteSpace(c)).ToArray()))
            {
               
                switch (c)
                {
                   
                    case 'L':
                        robotInitialOrientation = RobotFinalOrientationWhenInstructionIsL(robotInitialOrientation);
                        break;
                    case 'R':
                        robotInitialOrientation = RobotFinalOrientationWhenInstructionIsR(robotInitialOrientation);
                        break;
                    case 'M':
                        robotInitialXCoordinate = RobotFinalCoordinatesWhenInstructionIsM(robotInitialOrientation, robotInitialXCoordinate, ref robotInitialYCoordinate);

                        break;
                    default:
                        throw new Exception("Invalid character in the instruction! Sorry we can't  process it");
                }
            }
            //finally checking if the spider is not going beyound the allowed co-ordinates
            if (robotInitialXCoordinate <= robotMaxXCoordinate && robotInitialYCoordinate <= robotMaxYCoordinate)
            {
                return Tuple.Create(robotInitialXCoordinate, robotInitialYCoordinate,
                    robotInitialOrientation);
            }
            else
            {
                throw new Exception("Sorry :( Spider can not go beyound the allowed max coordinates");
            }
        }
        /// <summary>
        /// Robots the final orientation when instruction is R.
        /// </summary>
        /// <param name="robotInitialOrientation">The robot initial orientation.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Invalid robot orientation! Sorry we can't process it.</exception>
       public char RobotFinalOrientationWhenInstructionIsR(char robotInitialOrientation)
        {
            switch (robotInitialOrientation)
            {
                case 'L':

                    robotInitialOrientation = 'N';
                    break;
                case 'R':

                    robotInitialOrientation = 'S';
                    break;
                case 'S':

                    robotInitialOrientation = 'W';
                    break;
                case 'N':

                    robotInitialOrientation = 'E';
                    break;
                case 'W':

                    robotInitialOrientation = 'N';
                    break;
                case 'E':

                    robotInitialOrientation = 'S';
                    break;
                default:
                    throw new Exception("Invalid robot orientation! Sorry we can't process it.");
            }

            return robotInitialOrientation;
        }
        /// <summary>
        /// Robots the final orientation when instruction is L.
        /// </summary>
        /// <param name="robotInitialOrientation">The robot initial orientation.</param>
        /// <returns></returns>
        public char RobotFinalOrientationWhenInstructionIsL(char robotInitialOrientation)
        {
            switch (robotInitialOrientation)
            {
                case 'L':

                    robotInitialOrientation = 'S';
                    break;
                case 'R':

                    robotInitialOrientation = 'N';
                    break;
                case 'S':

                    //robotInitialOrientation = 'R';
                    robotInitialOrientation = 'E';
                    break;
                case 'N':
                    // robotInitialOrientation = 'L';
                    robotInitialOrientation = 'W';
                    break;

                case 'W':

                    robotInitialOrientation = 'S';
                    break;
                case 'E':

                    robotInitialOrientation = 'N';
                    break;

                default:
                    throw new Exception("Invalid robot orientation! Sorry we can't process it.");
            }

            return robotInitialOrientation;
        }
        /// <summary>
        /// Robots the final coordinates when instruction is F.
        /// </summary>
        /// <param name="robotInitialOrientation">The robot initial orientation.</param>
        /// <param name="robotInitialXCoordinate">The robot initial x coordinate.</param>
        /// <param name="robotInitialYCoordinate">The robot initial y coordinate.</param>
        /// <returns></returns>
        public int RobotFinalCoordinatesWhenInstructionIsM(char robotInitialOrientation, int robotInitialXCoordinate,
                    ref int robotInitialYCoordinate)
        {
            switch (robotInitialOrientation)
            {
                case 'L':
                    robotInitialXCoordinate--;
                    break;
                case 'R':
                    robotInitialXCoordinate++;
                    break;
                case 'N':

                    robotInitialYCoordinate++;
                    break;
                case 'S':

                    robotInitialYCoordinate--;
                    break;
                case 'E':
                    robotInitialXCoordinate++;
                    break;
                case 'W':
                    robotInitialXCoordinate--;
                    break;
                default:
                    throw new Exception("Invalid robot orientation! Sorry we can't process it.");
            }

            return robotInitialXCoordinate;
        }
    }
}
