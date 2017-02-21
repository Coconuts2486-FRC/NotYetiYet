using static CoconutsFrc2017.RobotMap;
using ChadDotNet;

namespace CoconutsFrc2017
{
    public class EmergencyMode : OperationMode
    {
        protected override void End()
        {
            
        }

        protected override void Init()
        {
        }

        bool flag = true;

        protected override void Main()
        {
            while (true)
            {
                DriveTrainObject.TankDrive(-DriveStick_Left.GetRawAxis(1), -DriveStick_Right.GetRawAxis(1));

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

                if (Custom_Board.GetRawButton(4))
                {
                    Shooter.Set(.9);
                    Agitator.Set(1);
                }

                else
                {
                    Shooter.Set(0);
                    Agitator.Set(0);
                }

                if (DriveStick_Left.GetRawButton(1) || DriveStick_Right.GetRawButton(1))
                {
                    if (flag)
                    {
                        Shifters.Set(!Shifters.Get());

                        flag = false;

                    }
                }

                else
                {
                    flag = true;
                }
                if (DriveStick_Left.GetRawAxis(2) > 0.1)
                {
                    PTO.Set(true);
                }

                else
                {
                    PTO.Set(false);
                }

                Shooter_Pivot.Set(.5 * Custom_Board.GetRawAxis(4));

                Snooze(10);
            }
        }
    }
}
