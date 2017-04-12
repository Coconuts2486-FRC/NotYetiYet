using WPILib;
using CTRE;
using CSCore;
using WPILib.Interfaces;
using System;
using WPILib.Extras.NavX;
using CoconutsFrc2017.Functions;
using WPILib.LiveWindow;

namespace CoconutsFrc2017
{
    /// <summary>
    /// Class for holding all robot objects.
    /// </summary>
    public static class RobotMap
    {
        // Definitions for setpoints on the robot.
        public const int FORWARD_SETPOINT = 10;
        public const int TURN_SETPOINT    = 10;

        // Properties for accessing motor devices.
        #region DeviceProperties
        /// <summary>
        /// Right motor of the drive train.
        /// Remember to enable BOTH right motors!
        /// </summary>
        /// <seealso cref="Right2"/>
        public static CANTalon Right1             { get { return can_06;   } }
        /// <summary>
        /// Second right motor of the drive train.
        /// Remember to enable BOTH right motors!
        /// </summary>
        /// <seealso cref="Right1"/>
        public static CANTalon Right2             { get { return can_07;   } }
        /// <summary>
        /// Left motor of the drive train.
        /// Remember to enable BOTH left motors!
        /// </summary>
        /// <seealso cref="Left2"/>
        public static CANTalon Left1              { get { return can_08;   } }
        /// <summary>
        /// Second left motor of the drive train.
        /// Remember to enable BOTH left motors!
        /// </summary>
        /// <seealso cref="Left1"/>
        public static CANTalon Left2              { get { return can_09;   } }
        /// <summary>
        /// Turn table for the shooter.
        /// Drives a belt that rotates the table.
        /// </summary>
        public static CANTalon Shooter_Pivot      { get { return can_05;   } }
        /// <summary>
        /// Fuel intake motor.
        /// Used in the front rollers.
        /// </summary>
        public static CANTalon Intake1            { get { return can_01;   } }
        /// <summary>
        /// Second fuel intake motor.
        /// As of 3/2/17, only the competition bot has this motor.
        /// </summary>
        public static CANTalon Intake2            { get { return can_02;   } }
        /// <summary>
        /// Fuel shooter motor.
        /// On the turntable, and is belt-driven.
        /// </summary>
        public static CANTalon Shooter            { get { return can_03;   } }
        /// <summary>
        /// Shooter intake motor.
        /// Pulls balls into shooter.
        /// </summary>
        public static CANTalon IntakeSecondStage       { get { return can_04;   } }
        /// <summary>
        /// Agitator motor.
        /// Plexiglass plates that spin on the inside of the bot to move balls around.
        /// </summary>
        public static CANTalon Agitator           { get { return can_10;   } }
        /// <summary>
        /// Solenoids for shifting the drive train into different gears.
        /// Located inside the gearbox.
        /// </summary>
        public static Solenoid Shifters           { get { return pcm_11_2; } }
        /// <summary>
        /// Solenoid for engaging the power take-off (PTO).
        /// Located near the shifters.
        /// </summary>
        public static Solenoid PTO                { get { return pcm_11_1; } }
        public static Solenoid GearSlot { get { return pcm_11_0; } }
        /// <summary>
        /// Left joystick.
        /// Located on the driver board.
        /// </summary>
        public static Joystick DriveStick_Left    { get { return usb_0;    } }
        /// <summary>
        /// Right joystick.
        /// Located on the driver board.
        /// </summary>
        public static Joystick DriveStick_Right   { get { return usb_1;    } }
        /// <summary>
        /// Custom driver board controls.
        /// Currently not built, consider this to be the gamepad.
        /// </summary>
        public static Joystick Custom_Board       { get { return usb_2;    } }
        /// <summary>
        /// Drive train object that incorporates the right and left motors.
        /// Contains useful methods for easy motor outputs.
        /// </summary>
        public static DriveTrainObject DriveTrain { get { return sw_0;     } }
        #endregion

        /// <summary>
        /// Initialize the controllers.
        /// </summary>
        public static void Init()
        {
            // Instantiates all the hardware devices with the respective ports.
            #region InstantiateDevices
            can_01 = new CANTalon(1);
            can_02 = new CANTalon(2);
            //can_02.MotorControlMode = ControlMode.Follower;
            //can_02.Set(can_01.DeviceId);
            //can_02.ReverseOutput(true);
            can_03 = new CANTalon(3);
            can_04 = new CANTalon(4);
            //can_04.MotorControlMode = ControlMode.Follower;
            //can_04.Set(can_03.DeviceId);
            can_05 = new CANTalon(5);
            can_06 = new CANTalon(6);
            can_07 = new CANTalon(7);
            can_08 = new CANTalon(8);
            can_09 = new CANTalon(9);
            can_10 = new CANTalon(10);
            can_11 = new Compressor(11);
            can_12 = new PowerDistributionPanel(12);
            pcm_11_0 = new Solenoid(11, 0);
            pcm_11_1 = new Solenoid(11, 1);
            pcm_11_2 = new Solenoid(11, 2);
            usb_0 = new Joystick(0);
            usb_1 = new Joystick(1);
            usb_2 = new Joystick(2);
            sw_0 = new DriveTrainObject(Left1, Left2, Right1, Right2);
            #endregion

            // Clears the sticky faults on all CAN devices.
            #region ClearCANStickyFaults
            can_01.ClearStickyFaults();
            can_02.ClearStickyFaults();
            can_03.ClearStickyFaults();
            can_04.ClearStickyFaults();
            can_05.ClearStickyFaults();
            can_06.ClearStickyFaults();
            can_07.ClearStickyFaults();
            can_08.ClearStickyFaults();
            can_09.ClearStickyFaults();
            can_10.ClearStickyFaults();
            can_11.ClearAllPCMStickyFaults();
            can_12.ClearStickyFaults();
            #endregion

            // Disable motor safety so that it doesn't stop motors from being output to.
            #region DisableSafety
            can_01.SafetyEnabled = false;
            can_02.SafetyEnabled = false;
            can_03.SafetyEnabled = false;
            can_04.SafetyEnabled = false;
            can_05.SafetyEnabled = false;
            can_06.SafetyEnabled = false;
            can_07.SafetyEnabled = false;
            can_08.SafetyEnabled = false;
            can_09.SafetyEnabled = false;
            can_10.SafetyEnabled = false;
            sw_0.SafetyEnabled   = false;
            #endregion
            
            Intake2.Inverted = true;
            Shooter_Pivot.Inverted = true;
            
            Intake1.Inverted = true;
            Agitator.Inverted = true;

            // Initializes the camera server with the default options.
            CameraServer.Instance.StartAutomaticCapture();
            //UsbCamera cam = new UsbCamera("cam0", 0);
            //cam.SetResolution(320, 240);
            //CameraServer.Instance.StartAutomaticCapture(cam);
            // Instantiates the NavX.
            NavX = new AHRS(SPI.Port.MXP);

            // Creates a new copy of the turntable.
            TurntableEncoder = new Encoder(8, 9);

            #region PID Controllers
            // Handles moving forwards and backwards for the shooter using the Pixy as the sensor.
            CamForward = new CamForwardPID(3.00, 0.00, 0.00, 0.00);

            // Handles the setpoint needed for the shooter using Pixy data.
            ShooterPos = new ShooterPosPID(3.00, 0.00, 0.00, 0.00);

            // Creates a new instance of the turn controller.
            TurnController = new TurningPID(new PIDF
            {
                kP = 0.0465, // 0.054
                kI = 0.00,
                kD = 0.00,
                kF = 0.00
            });

            // Sets the tolerance of the PID controller to 0.02.
            // Cancels the turning if the error is within 0.02.
            TurnController.Controller.SetAbsoluteTolerance(0.2);

            // Adds the PID controller to the Live Window for easier testing.
            LiveWindow.AddActuator("PID Controllers", "Turn Control", TurnController.Controller);
            #endregion
        }

        ///<summary>
        ///Stops all motors.
        ///</summary>
        public static void Stop()
        {
            can_01.Set(0);
            can_02.Set(0);
            can_03.Set(0);
            can_04.Set(0);
            can_05.Set(0);
            can_06.Set(0);
            can_07.Set(0);
            can_08.Set(0);
            can_09.Set(0);
            can_10.Set(0);
        }

        // This area is reserved for private IDs.
        // It only serves as references to the specific CAN bus IDs.
        #region PrivateIDs
        private static CANTalon can_01;
        private static CANTalon can_02;
        private static CANTalon can_03;
        private static CANTalon can_04;
        private static CANTalon can_05;
        private static CANTalon can_06;
        private static CANTalon can_07;
        private static CANTalon can_08;
        private static CANTalon can_09;
        private static CANTalon can_10;

        private static Compressor can_11;
        private static PowerDistributionPanel can_12;

        private static Solenoid pcm_11_0;
        private static Solenoid pcm_11_1;
        private static Solenoid pcm_11_2;

        private static Joystick usb_0;
        private static Joystick usb_1;
        private static Joystick usb_2;

        private static DriveTrainObject sw_0;

        /// <summary>
        /// The NavX 11-axis inertial measurement unit for reading acceleration,
        /// heading, magnetic disturbances, temperature, and pressure.
        /// </summary>
        public static AHRS NavX;

        /// <summary>
        /// The turning PID controller is for turning to a specific angle.
        /// </summary>
        public static TurningPID TurnController;

        /// <summary>
        /// Encoder for accessing positional data about the turntable.
        /// </summary>
        public static Encoder TurntableEncoder;

        /// <summary>
        /// Handles moving forwards and backwards for the shooter using the Pixy as the sensor.
        /// </summary>
        public static CamForwardPID CamForward;

        /// <summary>
        /// Handles the setpoint needed for the shooter using Pixy data.
        /// </summary>
        public static ShooterPosPID ShooterPos;
        #endregion
    }
}
