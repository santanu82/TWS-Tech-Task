﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpidersApp.Services
{
    public interface IOrientationServices
    {
        char RobotFinalOrientationWhenInstructionIsR(char robotInitialOrientation);
        char RobotFinalOrientationWhenInstructionIsL(char robotInitialOrientation);
    }
}
