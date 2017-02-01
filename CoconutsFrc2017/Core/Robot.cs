using System;
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
            
        }
    }
}
