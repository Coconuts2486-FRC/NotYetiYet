using ChadDotNet;
using CoconutsFrc2017.Functions;
using CTRE;
using WPILib;
using static CoconutsFrc2017.RobotMap;

namespace CoconutsFrc2017
{
    /// <summary>
    /// Class for creating an autonomous handler.
    /// </summary>
    public class Auto : OperationMode
    {
        // Creates a private instance of AutoHandler for running the selected autonomous mode.
        Handler AutoHandler;

        /// <summary>
        /// Initializes the AutoHandler.
        /// </summary>
        protected override void Init()
        {
            // Instantiates AutoHandler.
            AutoHandler = new Handler();

            // Sets the CAN Talons to rely off of the encoders for movement.
            AutoFunctions.ConfigureTalon(Right1, ConfigureType.Position, new EncoderParameters
            {
                AllowedError = 0,
                Device = CANTalon.FeedbackDevice.CtreMagEncoderRelative,
                NominalVoltage = 0.0f,
                PeakVoltage = 6.0f,
                PIDFValues = new PIDF
                {
                    kP = 0.126,
                    kI = 0,
                    kD = 0,
                    kF = 0
                },
                ReverseSensor = false
            });
            AutoFunctions.ConfigureTalon(Left1, ConfigureType.Position, new EncoderParameters
            {
                AllowedError = 0,
                Device = CANTalon.FeedbackDevice.CtreMagEncoderRelative,
                NominalVoltage = 0.0f,
                PeakVoltage = 6.0f,
                PIDFValues = new PIDF
                {
                    kP = 0.126,
                    kI = 0,
                    kD = 0,
                    kF = 0
                },
                ReverseSensor = true
            });

            Right1.SetEncoderPostition(0); // Reset the encoder position to 0.
            Right1.ReverseOutput(true);    // Reverse the direction of the motor.
            Right2.MotorControlMode = WPILib.Interfaces.ControlMode.Follower;
            Right2.Set(Right1.DeviceId);   // Configure the second right talon to be a follower of the other right talon.

            Left1.SetEncoderPostition(0);  // Reset the eoncoder position to 0.
            Left1.ReverseOutput(false);     // Reverse the direction of the motor.
            Left1.ReverseSensor(true);
            Left2.MotorControlMode = WPILib.Interfaces.ControlMode.Follower;
            Left2.Set(Left1.DeviceId);     // Configure the second left talon to be a follower of the other left talon.

            NavX.Reset(); // Reset the NavX's yaw value to zero.
        }

        /// <summary>
        /// Runs the auto handler.
        /// </summary>
        protected override void Main()
        {
            Right1.SetEncoderPostition(0); // Reset the encoder position to 0.
            Left1.SetEncoderPostition(0);  // Reset the eoncoder position to 0.
            // Runs the selected autonomous.

            // Both down. 0b00
            if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5)
            {
                SmartConsole.PrintInfo("Currently running disabled autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                AutoHandler.RunAuto(Handler.AutoPosition.Disabled);
            }
            // Left stick down, right stick up. 0b01
            else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5)
            {
                SmartConsole.PrintInfo("Currently running position 1 autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                AutoHandler.RunAuto(Handler.AutoPosition.Position1);
            }
            // Left stick up, right stick down. 0b10
            else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) < 0.5)
            {
                SmartConsole.PrintInfo("Currently running position 2 autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                AutoHandler.RunAuto(Handler.AutoPosition.Position2);
            }
            // Left stick up, right stick up. 0b11
            else if (DriveStick_Left.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5 && DriveStick_Right.GetAxis(WPILib.Joystick.AxisType.Z) > 0.5)
            {
                SmartConsole.PrintInfo("Currently running position 3 autonomous on the " + DriverStation.Instance.GetAlliance() + " alliance.");
                AutoHandler.RunAuto(Handler.AutoPosition.Position3);
            }
        }

        /// <summary>
        /// Resets the motors to use the VBus.
        /// </summary>
        protected override void End()
        {
            Right1.MotorControlMode = WPILib.Interfaces.ControlMode.PercentVbus;
            Right2.MotorControlMode = WPILib.Interfaces.ControlMode.PercentVbus;
            Left1.MotorControlMode  = WPILib.Interfaces.ControlMode.PercentVbus;
            Left2.MotorControlMode  = WPILib.Interfaces.ControlMode.PercentVbus;
            RobotMap.TurnController.Controller.Disable();
        }
    }
}