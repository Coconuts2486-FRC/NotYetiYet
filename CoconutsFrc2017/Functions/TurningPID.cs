using System;
using WPILib;
using WPILib.Interfaces;

namespace CoconutsFrc2017.Functions
{
    /// <summary>
    /// Class for allowing the drive train to turn according to a PID loop.
    /// Incorporates the gyro.
    /// </summary>
    public class TurningPID : IPIDOutput, IDataSource
    {
        /// <summary>
        /// Variable for holding the PID controller.
        /// Allows manual configuration of its parameters.
        /// </summary>
        public PIDController Controller;

        /// <summary>
        /// Create a new instance of TurningPID with the supplied PIDF struct.
        /// </summary>
        /// <param name="values">The PIDF values to use.</param>
        public TurningPID(PIDF values) : this(values.kP, values.kI, values.kD, values.kF) { }

        /// <summary>
        /// Creates a new instance of TurningPID with the supplied PIDF values.
        /// </summary>
        /// <param name="kp">Proportional gain.</param>
        /// <param name="ki">Integral gain.</param>
        /// <param name="kd">Derivative gain.</param>
        /// <param name="kf">Filter gain.</param>
        public TurningPID(double kp, double ki, double kd, double kf)
        {
            try
            {
                // Set the NavX to run off of displacement.
                // Means it will return the distance from the start of the PID control.
                RobotMap.NavX.PIDSourceType = PIDSourceType.Displacement;

                // Create a new PID controller with the given PIDF values and NavX.
                Controller = new PIDController(kp, ki, kd, kf, RobotMap.NavX, this);

                // Sets the input range of the controller to be -180 degrees to 180 degrees.
                Controller.SetInputRange(-180f, 180f);

                // Sets the peak output to be 45% power on the drive train.
                Controller.SetOutputRange(-0.45, 0.45);

                // Allow for a tolerance of 10 when turning.
                Controller.SetAbsoluteTolerance(0.1);
            }
            catch (Exception ex) { DriverStation.ReportError(ex.Message, true); }
        }

        /// <summary>
        /// Tells the PID controller where to get data from.
        /// Equivalent of calling <c>RobotMap.NavX.GetYaw()</c>.
        /// </summary>
        /// <returns>Current yaw reading from -180f to 180f.</returns>
        public double GetData()
        {
            // Return the current yaw reading from the NavX.
            return RobotMap.NavX.GetYaw();
        }

        /// <summary>
        /// Write to the drive train motors.
        /// The right is set to -value, while the left is value.
        /// </summary>
        /// <param name="value">Speed to write as.</param>
        public void PidWrite(double value)
        {
            // Output the value from the PID controller to the motors.
            RobotMap.DriveTrain.SetLeftRightMotorOutputs(value, -value);
        }
    }

    /// <summary>
    /// Configuration file for PIDF values.
    /// </summary>
    public struct PIDF
    {
        /// <summary>
        /// Proportional gain.
        /// Determines the linear relationship of the data.
        /// </summary>
        public double kP { get; set; }
        /// <summary>
        /// Integral gain.
        /// Determines the integral, or total amount of change since starting.
        /// </summary>
        public double kI { get; set; }
        /// <summary>
        /// Derivative gain.
        /// Reduces the amount of oscillation by predicting the future.
        /// The derivative is the tangent of a given point in a function.
        /// </summary>
        public double kD { get; set; }
        /// <summary>
        /// Filter gain.
        /// Adds a constant to the output.
        /// </summary>
        public double kF { get; set; }
    }
}