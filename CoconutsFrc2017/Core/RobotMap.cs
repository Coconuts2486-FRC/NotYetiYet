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
        public static PowerDistributionPanel PDP { get; private set; }
        public static Compressor PCM { get; private set; }
        public static RobotDrive DriveTrain { get; private set; }
        public static Solenoid Gearbox { get; private set; }
        public static Solenoid PTO { get; private set; }

        public static void Init()
        {
            Right1 = new CANTalon(3);
            Right1.SafetyEnabled = false;

            Right2 = new CANTalon(4);
            Right2.SafetyEnabled = false;

            Left1 = new CANTalon(1);
            Left1.SafetyEnabled = false;
            Left1.ReverseOutput(true);

            Left2 = new CANTalon(2);
            Left2.SafetyEnabled = false;
            Left2.ReverseOutput(true);

            PDP = new PowerDistributionPanel();
            PDP.ClearStickyFaults();

            PCM = new Compressor(17);
            PCM.ClearAllPCMStickyFaults();

            DriveTrain = new RobotDrive(Left1, Left2, Right1, Right2);
            DriveTrain.SafetyEnabled = false;

            Gearbox = new Solenoid(17, 0);

            PTO = new Solenoid(17, 1);
        }
    }
}
