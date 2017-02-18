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
                DriveTrain.TankDrive(-DriveStick_Left.GetRawAxis(1), -DriveStick_Right.GetRawAxis(1));

                if ((DriveStick_Left.GetRawAxis(1) < -0.1 || DriveStick_Right.GetRawAxis(1) < -0.1) && !Custom_Board.GetRawButton(4))
                {
                    Intake1.Set(-1);
                    Intake2.Set(-1);
                }

                else
                {
                    Intake1.Set(0);
                    Intake2.Set(0);
                }

                if (Custom_Board.GetRawButton(4)) Shooter.Set(1);
                else Shooter.Set(0);

                Shooter_Pivot.Set(.5 * Custom_Board.GetRawAxis(4));

                Snooze(10);
            }
        }

        protected override void End()
        {
            Stop();
        }
    }
}