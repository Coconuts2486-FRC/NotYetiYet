using WPILib;
using CTRE;

namespace CoconutsFrc2017.Core
{
    public static class RobotMap
    {
        public static Talon Right1 { get; private set; }
        public static Talon Right2 { get; private set; }
        public static Talon Left1 { get; private set; }
        public static Talon Left2 { get; private set; }
        public static PowerDistributionPanel PDP { get; private set; }
        public static Compressor PCM { get; private set; }
        public static RobotDrive DriveTrain { get; private set; }
        public static Solenoid Gearbox { get; private set; }
        public static Solenoid PTO { get; private set; }
        public static Joystick DriveLeft { get; private set; }
        public static Joystick DriveRight { get; private set; }

        public static void Init()
        {
            Right1 = new Talon(0);
            Right1.SafetyEnabled = false;

            Right2 = new Talon(1);
            Right2.SafetyEnabled = false;

            Left1 = new Talon(2);
            Left1.SafetyEnabled = false;
            Left1.Inverted = true;

            Left2 = new Talon(3);
            Left2.SafetyEnabled = false;
            Left2.Inverted = true;

            PDP = new PowerDistributionPanel();
            PDP.ClearStickyFaults();

            PCM = new Compressor(17);
            PCM.ClearAllPCMStickyFaults();

            DriveTrain = new RobotDrive(Left1, Left2, Right1, Right2);
            DriveTrain.SafetyEnabled = false;

            Gearbox = new Solenoid(17, 0);

            PTO = new Solenoid(17, 1);

            DriveLeft = new Joystick(0);

            DriveRight = new Joystick(1);
        }
    }
}
