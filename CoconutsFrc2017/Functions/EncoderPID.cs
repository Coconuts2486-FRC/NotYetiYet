using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPILib;
using WPILib.Interfaces;

namespace CoconutsFrc2017.Functions
{
    /// <summary>
    /// Class for attaching a motor and an encoder together with a PID relationship.
    /// </summary>
    public class EncoderPID : IPIDOutput
    {
        /// <summary>
        /// Variable for holding the PID controller.
        /// Allows manual configuration of its parameters.
        /// </summary>
        public PIDController Controller;
        
        /// <summary>
        /// Motor to output to.
        /// </summary>
        private ISpeedController _SpeedController;

        /// <summary>
        /// Creates a new instance of EncoderPID with the supplied speed controller and PIDF values.
        /// </summary>
        /// <param name="speedController">Speed controller to use, such as <c>CANTalon</c> or <c>Spark</c></param>
        /// <param name="encoder">Encoder for measuring positional data.</param>
        /// <param name="values">The PIDF values to use.</param>
        public EncoderPID(ISpeedController speedController, Encoder encoder, PIDF values) 
            : this(speedController, encoder, values.kP, values.kI, values.kD, values.kF) { }

        /// <summary>
        /// Creates a new instance of EncoderPID with the supplied speed controller and PIDF values.
        /// </summary>
        /// <param name="speedController">Speed controller to use, such as <c>CANTalon</c> or <c>Spark</c></param>
        /// <param name="encoder">Encoder for measuring positional data.</param>
        /// <param name="kP">Proportional gain.</param>
        /// <param name="kI">Integral gain.</param>
        /// <param name="kD">Derivative gain.</param>
        /// <param name="kF">Filter gain.</param>
        public EncoderPID(ISpeedController speedController, Encoder encoder, double kP, double kI, double kD, double kF)
        {
            // Set the speed controller equal to something.
            _SpeedController = speedController;

            // Create a new instance of the PID controller.
            Controller = new PIDController(kP, kI, kD, kF, encoder, this);

            // Set the inputs for the encoder. Limits the range it can go.
            Controller.SetInputRange (0   , 100) ;

            // Sets the output range of the motor.
            Controller.SetOutputRange(-0.5, 0.5);
        }

        /// <summary>
        /// Output to the motor to turn.
        /// </summary>
        /// <param name="value"></param>
        public void PidWrite(double value)
        {
            _SpeedController.Set(value);
        }
    }
}
