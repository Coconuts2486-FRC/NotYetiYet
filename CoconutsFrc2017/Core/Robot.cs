using System;
using ChadDotNet;

namespace CoconutsFrc2017
{
    public class Robot : ThreadedRobot
    {
        protected override void Init()
        {
            RobotMap.Init();
            AutonomousThread = new Auto();
            DisabledThread = new Disable();
            TeleopThread = new TeleOp();
            TestThread = new Test();

        }
    }
}
