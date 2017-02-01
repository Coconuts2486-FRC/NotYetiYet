using System;
using CoconutsFrc2017.OpModes;
using ChadDotNet.System;
namespace CoconutsFrc2017.Core
{
    public class Robot : ThreadedRobot
    {
        protected override void init()
        {
            RobotMap.Init();
        }

        protected override void SetThreads()
        {
            TeleopThread = new TeleOp();
            AutonomousThread = new Auto();
            TestThread = new Test();
            DisabledThread = new Disabled();
        }
    }
}
