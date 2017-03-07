using ChadDotNet;
using NetworkTables;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CoconutsFrc2017
{
    /// <summary>
    /// Autonomous mode for doing nothing.
    /// Enable this in case of emergency!
    /// </summary>
    public class Disabled : IAuto
    {
        /// <summary>
        /// Runs the disabled autonomous.
        /// Does nothing. Meant for if something catastrophic occurs.
        /// Compatible with anywhere.
        /// </summary>
        public void Run()
        {
            RobotMap.Right1.Set(50);
            RobotMap.Left1.Set(50);
            // Sleeps for 15 seconds.
            Thread.Sleep(15000);
        }
    }
}
