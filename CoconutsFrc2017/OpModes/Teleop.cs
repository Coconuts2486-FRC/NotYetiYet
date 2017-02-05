using ChadDotNet.System;
using static CoconutsFrc2017.Core.RobotMap;

namespace CoconutsFrc2017.OpModes
{
    public class TeleOp : OperationMode
    {
        protected override void End()
        {
        }

        protected override void Init()
        {
        }

        protected override void Main()
        {
            while (true)
            {
                DriveTrain.TankDrive(DriveLeft.GetY(), DriveRight.GetY());

                if (Gamepad.GetRawButton(1)) Shooter.Set(1);
                else Shooter.Set(0);
                Snooze(10);
            }
        }
    }
}