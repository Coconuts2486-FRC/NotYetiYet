using System.Threading;

namespace CoconutsFrc2017
{
    public class Disabled : IAuto
    {
        /// <summary>
        /// Runs the disabled autonomous.
        /// Does nothing. Meant for if something catastrophic occurs.
        /// Compatible with anywhere.
        /// </summary>
        public void Run()
        {
            RobotMap.Left1.Set(1);
            RobotMap.Left2.Set(1);
            // Sleeps for 15 seconds.
            Thread.Sleep(15000);
        }
    }
}
