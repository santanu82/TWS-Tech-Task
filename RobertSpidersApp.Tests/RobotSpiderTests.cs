// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System;
using NUnit.Framework;
using RobotSpidersApp.Services;

namespace RobertSpidersApp.Tests
{
    [TestFixture]
    public class RobotSpiderTests
    {
        private readonly IRobotServices myRobotServices = new RobotServices();

        //setting up the testing environment
        [Test]
        public void TestMethod()
        {
            Assert.Pass();
        }
        [Test]
        //Case1
        //Robot initial co-ordinates and orientation is (1,2,N)
        //Robot instruction is LMLMLMLMM
        public void TestingRobotFinalLocationAndDirection_For_Case1()
        {
            //Arrange test

            
            var maxCoordinatesOfRobot = Tuple.Create(5, 5);
            var robotInitialCoordinatesAndOrientation = Tuple.Create(1, 2, 'N');

            const string robotInstruction = "LMLMLMLMM";

            //Act test

            var expectedRobotFinalCoordinatesAndOrientation = Tuple.Create(1, 3, 'N');
            var actualRobotFinalCoordinatesAndOrientation = myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot, 
                                                                                                                robotInitialCoordinatesAndOrientation,
                                                                                                                robotInstruction);
           
            //Assert test
            
           Assert.AreEqual(expectedRobotFinalCoordinatesAndOrientation,actualRobotFinalCoordinatesAndOrientation);
           
        }
        [Test]
        //Case2
        //Robot initial co-ordinates and orientation is (3,3,E)
        //Robot instruction is MMRMMRMRRM
        public void TestingRobotFinalLocationAndDirection_For_Case2()
        {
            //Arrange test


            var maxCoordinatesOfRobot = Tuple.Create(5, 5);
            var robotInitialCoordinatesAndOrientation = Tuple.Create(3, 3, 'E');

            const string robotInstruction = "MMRMMRMRRM";

            //Act test

            var expectedRobotFinalCoordinatesAndOrientation = Tuple.Create(5, 1, 'E');
            var actualRobotFinalCoordinatesAndOrientation = myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot,
                robotInitialCoordinatesAndOrientation,
                robotInstruction);

            //Assert test

            Assert.AreEqual(expectedRobotFinalCoordinatesAndOrientation, actualRobotFinalCoordinatesAndOrientation);

        }
        [Test]
        public void TestingRobotFinalLocationAndDirectionWhenInstructionHaveEmptyIntermediateChar()
        {
            //Arrange test


            var maxCoordinatesOfRobot = Tuple.Create(7, 5);
            var robotInitialCoordinatesAndOrientation = Tuple.Create(2, 4, 'L');
            const string robotInstruction = "MLMLM    RMMLM";

            //Act test

            var expectedRobotFinalCoordinatesAndOrientation = Tuple.Create(3, 1, 'E');
            var actualRobotFinalCoordinatesAndOrientation = myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot,
                robotInitialCoordinatesAndOrientation,
                robotInstruction);

            //Assert test

            Assert.AreEqual(expectedRobotFinalCoordinatesAndOrientation, actualRobotFinalCoordinatesAndOrientation);

        }
        [Test]
        public void TestingRobotFinalLocationAndDirectionWhenInstructionHaveEmptyCharInBegining()
        {
            //Arrange test


            var maxCoordinatesOfRobot = Tuple.Create(7, 5);
            var robotInitialCoordinatesAndOrientation = Tuple.Create(2, 4, 'L');
            const string robotInstruction = "    MLMLMRMMLM";

            //Act test

            var expectedRobotFinalCoordinatesAndOrientation = Tuple.Create(3, 1, 'E');
            var actualRobotFinalCoordinatesAndOrientation = myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot,
                robotInitialCoordinatesAndOrientation,
                robotInstruction);

            //Assert test

            Assert.AreEqual(expectedRobotFinalCoordinatesAndOrientation, actualRobotFinalCoordinatesAndOrientation);

        }
        [Test]
        public void TestingRobotFinalLocationAndDirectionWhenInstructionHaveEmptyCharInEnd()
        {
            //Arrange test


            var maxCoordinatesOfRobot = Tuple.Create(7, 5);
            var robotInitialCoordinatesAndOrientation = Tuple.Create(2, 4, 'W');
            var robotInstruction = "MLMLMRMMLM    ";

            //Act test

            var expectedRobotFinalCoordinatesAndOrientation = Tuple.Create(3, 1, 'E');
            var actualRobotFinalCoordinatesAndOrientation = myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot,
                robotInitialCoordinatesAndOrientation,
                robotInstruction);

            //Assert test

            Assert.AreEqual(expectedRobotFinalCoordinatesAndOrientation, actualRobotFinalCoordinatesAndOrientation);

        }
        [Test]
        public void GettingCorrectErrorMessageWhenWrongRobotCoordinatesWereProvided()
        {
            //Arrange test


            var maxCoordinatesOfRobot = Tuple.Create(7, 5);
            //providing wrong robot coordinates
            var robotInitialCoordinatesAndOrientation = Tuple.Create(2, 4, 'B');
            var robotInstruction = "MLMLMRMMLM";

            //Act test

            var expectedErrorMessage = "Invalid robot orientation! Sorry we can't process it.";
            var actualErrorMessage = Assert.Throws<Exception>(() =>
                myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot,
                    robotInitialCoordinatesAndOrientation,
                    robotInstruction));

            //Assert test

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage.Message);

        }

        [Test]
        public void GettingCorrectErrorMessageWhenInvalidRobotInstructionIsProvided()
        {
            //Arrange test
           

            var maxCoordinatesOfRobot = Tuple.Create(7, 5);
            var robotInitialCoordinatesAndOrientation = Tuple.Create(2, 4, 'L');
            //providing wrong robot instruction
            var robotInstruction = "MLMLMRMMLG";

            //Act test

            var expectedErrorMessage = "Invalid character in the instruction! Sorry we can't  process it";
            var actualErrorMessage = Assert.Throws<Exception>(() =>
                myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot,
                    robotInitialCoordinatesAndOrientation,
                    robotInstruction));

            //Assert test

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage.Message);
        }
        [Test]
        public void GettingCorrectErrorMessageWhenRobotGoBeyoundTheMaxCoordinatesAssigned()
        {
            //Arrange test


            var maxCoordinatesOfRobot = Tuple.Create(7, 5);
            var robotInitialCoordinatesAndOrientation = Tuple.Create(2, 4, 'L');
            var robotInstruction = "MLMLMRMMLMMMMMMMMMMLLLLRRRRMMMMMLLLLMMMRRR";

            //Act test

            var expectedErrorMessage = "Sorry :( Spider can not go beyound the allowed max coordinates";
            var actualErrorMessage = Assert.Throws<Exception>(() =>
                myRobotServices.GetRobotFinalCoordinateAndOrientation(maxCoordinatesOfRobot,
                    robotInitialCoordinatesAndOrientation,
                    robotInstruction));

            //Assert test

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage.Message);

        }

    }
}
