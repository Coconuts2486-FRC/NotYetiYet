using ChadDotNet;
using WPILib.LiveWindow;
using WPILib.SmartDashboard;

namespace CoconutsFrc2017
{
    public class Test : OperationMode
    {
        protected override void End()
        {
            LiveWindow.SetEnabled(false);
        }

        protected override void Init()
        {
            LiveWindow.SetEnabled(true);
        }

        protected override void Main()
        {
            LiveWindow.Run();
            SmartDashboard.PutNumber("NavX GetYaw", RobotMap.NavX.GetYaw());
        }
    }
}