using ChadDotNet;
using System;
using WPILib;
using WPILib.SmartDashboard;

namespace CoconutsFrc2017
{
    static class AutoFunctions
    {
        /// <summary>
        /// Drives the specified distance.
        /// Enter a negative amount to drive backwards.
        /// </summary>
        /// <param name="desiredDistance">Distance in meters.</param>
        public static void Drive(double desiredDistance)
        {

        }

        /// <summary>
        /// Drive the specified encoder ticks.
        /// </summary>
        /// <param name="encoderTicks">Distance in encoder ticks.</param>
        public static void Drive(int encoderTicks)
        {

        }

        /// <summary>
        /// Convert linear meters to ticks.
        /// </summary>
        /// <param name="input">Amount of meters.</param>
        /// <returns>Number of ticks.</returns>
        private static int MetersToTicks(double input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Drive to the desired angle.
        /// </summary>
        /// <param name="desiredAngle">Desired angle from -180 to 180.</param>
        public static void TurnToAngle(double desiredAngle)
        {
            RobotMap.TurnController.Controller.Setpoint = desiredAngle;
            RobotMap.TurnController.Controller.Enable();
            while (RobotMap.TurnController.Controller.OnTarget() == false)
            {
            }
            RobotMap.TurnController.Controller.Disable();
        }

        /// <summary>
        /// Place the gear on the peg.
        /// </summary>
        public static void PlaceGear()
        {

        }

        /// <summary>
        /// Shoot balls until interrupted.
        /// </summary>
        public static void ShootFuel()
        {

        }

        /// <summary>
        /// Align to the target then shoot for the supplied amount of time.
        /// </summary>
        /// <param name="TimeFor">Once at the target, shoot for this long.</param>
        public static void ShootFuel(long TimeFor)
        {

        }
    }
}
