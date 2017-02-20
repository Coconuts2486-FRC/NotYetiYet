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
            // Sleeps for 15 seconds.
            Thread.Sleep(15000);
        }
    }
}
