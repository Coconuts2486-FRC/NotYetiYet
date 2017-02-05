using WPILib;
using CTRE;

namespace CoconutsFrc2017.Core
{
    public static class RobotMap
    {
        public static CANTalon Right1 { get; private set; }
        public static CANTalon Right2 { get; private set; }
        public static CANTalon Left1 { get; private set; }
        public static CANTalon Left2 { get; private set; }
        public static CANTalon Shooter { get; private set; }
        public static PowerDistributionPanel PDP { get; private set; }
        public static Compressor PCM { get; private set; }
        public static RobotDrive DriveTrain { get; private set; }
        public static Solenoid Gearbox { get; private set; }
        public static Solenoid PTO { get; private set; }
        public static Joystick DriveLeft { get; private set; }
        public static Joystick DriveRight { get; private set; }
        public static Joystick Gamepad { get; private set; }

        public static void Init()
        {
       
            Right1 = new CANTalon(3);
            Right1.SafetyEnabled = false;
            Right1.ClearStickyFaults();

            Right2 = new CANTalon(4);
            Right2.SafetyEnabled = false;
            Right2.ClearStickyFaults();

            Left1 = new CANTalon(1);
            Left1.SafetyEnabled = false;
            Left1.Inverted = true;
            Left1.ClearStickyFaults();

            Left2 = new CANTalon(8);
            Left2.SafetyEnabled = false;
            Left2.Inverted = true;
            Left2.ClearStickyFaults();

            Shooter = new CANTalon(2);
            Shooter.SafetyEnabled = false;
            Shooter.Inverted = true;
            Shooter.ClearStickyFaults();

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

            Gamepad = new Joystick(2);
        }
    }
}
