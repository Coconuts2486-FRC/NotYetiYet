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
            //AutoFunctions.Drive(0.5);
            //AutoFunctions.Drive(-0.5);
            //AutoFunctions.Drive(1);

            AutoFunctions.TurnToAngle(-177);
            AutoFunctions.Drive(0.5);
            AutoFunctions.TurnToAngle(50);
            //AutoFunctions.Drive(-0.5);
        }
    }
}
