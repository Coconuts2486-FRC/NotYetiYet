using ChadDotNet;
using static CoconutsFrc2017.RobotMap;
using WPILib.SmartDashboard;
using System.Threading;
using WPILib;

namespace CoconutsFrc2017
{
    public class Disable : OperationMode
    {
        protected override void End()
        {
        }

        protected override void Init()
        {
            
        }

        protected override void Main()
        {
#if DEBUG
            SmartConsole.PrintWarning("Robot running in debug mode.");
#endif

            Handler.AutoPosition position = Handler.AutoPosition.Disabled;

            while (true)
            {
                // Both down. 0b00
                if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5)
                {
                    SmartConsole.PrintInfo("Currently running disabled autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                    position = Handler.AutoPosition.Disabled;
                    //AutoHandler.RunAuto(Handler.AutoPosition.Disabled);
                }
                // Left stick down, right stick up. 0b01
                else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5)
                {
                    SmartConsole.PrintInfo("Currently running position 1 autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                    position = Handler.AutoPosition.Position1;
                    //AutoHandler.RunAuto(Handler.AutoPosition.Position1);
                }
                // Left stick up, right stick down. 0b10
                else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5)
                {
                    SmartConsole.PrintInfo("Currently running position 2 autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                    position = Handler.AutoPosition.Position2;
                    //AutoHandler.RunAuto(Handler.AutoPosition.Position2);
                }
                // Left stick up, right stick up. 0b11
                else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && position != Handler.AutoPosition.Position3)
                {
                    SmartConsole.PrintInfo("Currently running position 3 autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                    position = Handler.AutoPosition.Position3;
                    //AutoHandler.RunAuto(Handler.AutoPosition.Position3);
                }
            }
        }
    }
}