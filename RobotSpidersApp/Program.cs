using System;
using RobotSpidersApp.Services;

namespace RobotSpidersApp
{
    public class Program
    {
        #region For Future
        /*************
        private readonly IRobotServices _myRobotServices;
        //constructor injection
        public Program(IRobotServices myRobotServices)
        {
            _myRobotServices = myRobotServices;
        }
        ******************/
        #endregion
        private static readonly IRobotServices myRobotServices = new RobotServices();

        static void Main()
        {
            Console.Beep();
            Console.WriteLine("***********************Welcome to Robot Spider App**********************");
            try
            {
                Console.Beep();
                Console.WriteLine("Please provide the maximum X-Coordinate for the Robot");
                //reading the maximum x-coordinate value from the console by the user
                var maxXCoordinateOfRobot = Convert.ToInt32(Console.ReadLine());
                Console.Beep();
                Console.WriteLine("Please provide the maximum Y-Coordinate for the Robot");
                //reading the maximum y-coordinate value from the console by the user
                var maxYCoordinateOfRobot = Convert.ToInt32(Console.ReadLine());
                Console.Beep();
                Console.WriteLine("Please provide the current X-Coordinate of the robot");
                //reading the current x-coordinate value from the console by the user
                var currentXCoordinateofRobot = Convert.ToInt32(Console.ReadLine());
                Console.Beep();
                Console.WriteLine("Please provide the current Y-Coordinate of the robot");
                //reading the current y-coordinate value from the console by the user
                var currentYCoordinateofRobot = Convert.ToInt32(Console.ReadLine());
                Console.Beep();
                Console.WriteLine("Please provide the current orientation of the robot");
                //reading the robot current orientation value from the console by the user
                var currentOrientationOfRobot = Convert.ToChar(Console.ReadLine());
                Console.Beep();
                Console.WriteLine("Please provide the robot instruction");
                //reading the robot instruction from the console by the user
                var robotInstruction = Console.ReadLine();
                //creating tuple for maximum permissible co-ordinate for robot 
                var robotMaxCoordinates = Tuple.Create(maxXCoordinateOfRobot, maxYCoordinateOfRobot);
                //creating tuple for robot's current coordinate and orientation
                var robotInitalCoordinateAndOreintation = Tuple.Create(currentXCoordinateofRobot,
                    currentYCoordinateofRobot, currentOrientationOfRobot);
                //getting the final coordinate and orientation of robot in tuple format
                //by calling the GetRobotFinalCoordinateAndOrientation() method of RobotService class
                var finalCoordinateAndOreintationOfRobot =
                    myRobotServices.GetRobotFinalCoordinateAndOrientation(robotMaxCoordinates,
                        robotInitalCoordinateAndOreintation, robotInstruction);
                //displaying robot's final x-y coordinate along with the orienation
                Console.WriteLine($"Robort final coordinates and orientation is {finalCoordinateAndOreintationOfRobot.Item1} {finalCoordinateAndOreintationOfRobot.Item2} {finalCoordinateAndOreintationOfRobot.Item3} ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry there is some error occured: "+e.Message);
               
            }

            Console.ReadLine();

        }
    }
}
