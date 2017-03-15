using ChadDotNet;
using WPILib.SmartDashboard;

namespace CoconutsFrc2017
{
    public class Disable : OperationMode
    {
        protected override void End()
        {
        }

        protected override void Init()
        {
#if DEBUG
            SmartDashboard.PutBoolean("Debug?", true);
            SmartConsole.PrintWarning("In debug mode.");
#endif
        }

        protected override void Main()
        {

        }
    }
}