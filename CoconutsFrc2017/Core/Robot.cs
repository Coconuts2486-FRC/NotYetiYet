using System;
using CoconutsFrc2017.OpModes;
using ChadDotNet.System;
using ChadDotNet.Network;
using NativeLibraryUtilities;
namespace CoconutsFrc2017.Core
{
    public class Robot : ThreadedRobot
    {
        protected override void init()
        {
            try
            {
                RobotMap.Init();
            }
            catch (Exception e)
            {
                SmartConsole.PrintInfo(e.Message);
                SmartConsole.PrintInfo(e.StackTrace);
            }
            
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
