using CoconutsFrc2017;

namespace CoconutsFrc2017
{
    class Handler
    {
        public enum AutoMode
        {
            Disabled = 0,
            Red1     = 1,
            Red2     = 2,
            Red3     = 3,
            Blue1    = 5,
            Blue2    = 6,
            Blue3    = 7
        }

        public enum AutoPosition
        {
            Disabled  = 0,
            Position1 = 1,
            Position2 = 2,
            Position3 = 3
        }

        private AutoMode GetAuto(AutoPosition mode)
        {
            if (mode == 0)                                                                         // Switches are not enabled.
                return AutoMode.Disabled;
            if (WPILib.DriverStation.Instance.GetAlliance() == WPILib.DriverStation.Alliance.Blue) // Alliance is blue. Shift by 2^2.
                return (AutoMode)(mode += 4 * (byte)WPILib.DriverStation.Alliance.Blue);
            else return (AutoMode)mode;                                                            // Return mode.
        }

        public void RunAuto(AutoPosition position)
        {
            IAuto auto;
            switch (GetAuto(position))
            {
                case AutoMode.Disabled:
                    auto = new Disabled();
                    break;
                case AutoMode.Red1:
                    auto = new Red1();
                    break;
                case AutoMode.Red2:
                    auto = new Red2();
                    break;
                case AutoMode.Red3:
                    auto = new Red3();
                    break;
                case AutoMode.Blue1:
                    auto = new Blue1();
                    break;
                case AutoMode.Blue2:
                    auto = new Blue2();
                    break;
                case AutoMode.Blue3:
                    auto = new Blue3();
                    break;
                default:
                    auto = new Disabled();
                    break;
            }
            auto.Run();
        }
    }
}