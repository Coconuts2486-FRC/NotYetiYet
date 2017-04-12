using ChadDotNet;
using static CoconutsFrc2017.RobotMap;
using WPILib.SmartDashboard;
using System.Threading;
using WPILib;

namespace CoconutsFrc2017
{
    public class Disable : OperationMode
    {
        private bool a0;
        private bool a1;
        private bool a2;
        private bool a3;

        protected override void End()
        {
        }

        protected override void Init()
        {
            a0 = false;
            a1 = false;
            a2 = false;
            a3 = false;
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
                    if (!a0)
                    {
                        SmartConsole.PrintInfo("Currently running disabled autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                        position = Handler.AutoPosition.Disabled;
                        //AutoHandler.RunAuto(Handler.AutoPosition.Disabled);
                        a0 = true;
                        a1 = false;
                        a2 = false;
                        a3 = false;
                    }
                }
                // Left stick down, right stick up. 0b01
                else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5)
                {
                    if (!a1)
                    {
                        SmartConsole.PrintInfo("Currently running side gear (positon 1) autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                        position = Handler.AutoPosition.Position1;
                        //AutoHandler.RunAuto(Handler.AutoPosition.Position1);
                        a0 = false;
                        a1 = true;
                        a2 = false;
                        a3 = false;
                    }
                }
                // Left stick up, right stick down. 0b10
                else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5)
                {
                    if (!a2)
                    {
                        SmartConsole.PrintInfo("Currently running center gear (positon 2) autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                        position = Handler.AutoPosition.Position2;
                        //AutoHandler.RunAuto(Handler.AutoPosition.Position2);
                        a0 = false;
                        a1 = false;
                        a2 = true;
                        a3 = false;
                    }
                }
                // Left stick up, right stick up. 0b11
                else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && position != Handler.AutoPosition.Position3)
                {
                    if (!a3)
                    {
                        SmartConsole.PrintInfo("Currently running position 3 autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                        position = Handler.AutoPosition.Position3;
                        //AutoHandler.RunAuto(Handler.AutoPosition.Position3);
                        a0 = false;
                        a1 = false;
                        a2 = false;
                        a3 = true;
                    }
                }
            }
        }
    }
}