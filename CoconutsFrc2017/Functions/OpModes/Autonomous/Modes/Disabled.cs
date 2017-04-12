using ChadDotNet;
using NetworkTables;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using WPILib.SmartDashboard;
using static CoconutsFrc2017.RobotMap;

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
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //while (true)
            //{
            //Right1.Set(50);
            //Left1.Set(50);
            //}
            // TEST CODE PLEASE IGNORE

            //AutoFunctions.Drive(0.5);
            //while (OnTarget())
            //{
            //    SmartDashboard.PutBoolean("In loop?", true);
            //    SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
            //    SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            //}
            //SmartDashboard.PutBoolean("In loop?", false);
            //AutoFunctions.TurnToAngle(90);
            //AutoFunctions.Drive(0.5);
            //while (OnTarget())
            //{
            //    SmartDashboard.PutBoolean("In loop?", true);
            //    SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
            //    SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            //}
            //SmartDashboard.PutBoolean("In loop?", false);
        }

        public bool OnTarget()
        {
            SmartDashboard.PutNumber("Left Difference", Math.Abs(-RobotMap.Left1.GetEncoderPosition() / 4096 - RobotMap.Left1.Setpoint));
            SmartDashboard.PutNumber("Right Difference", Math.Abs(RobotMap.Right1.Setpoint - RobotMap.Right1.GetEncoderPosition() / 4096));
            return (Math.Abs(-RobotMap.Left1.GetEncoderPosition() / 4096 - RobotMap.Left1.Setpoint) > 0.84 || Math.Abs(RobotMap.Right1.Setpoint - RobotMap.Right1.GetEncoderPosition() / 4096) > 0.84);
        }
    }
}
