using ChadDotNet.System;
using static CoconutsFrc2017.Core.RobotMap;

namespace CoconutsFrc2017.OpModes
{
    public class TeleOp : OperationMode
    {

        protected override void Init()
        {
        }

        protected override void Main()
        {
            while (true)
            {
                DriveTrain.TankDrive(DriveLeft.GetY(), -DriveRight.GetY());

                if (DriveLeft.GetY() < -0.1 || DriveRight.GetY() < -0.1) Collector.Set(1);
                else Collector.Set(0);
                
            }
        }


        protected override void End()
        {
        }
    }
}