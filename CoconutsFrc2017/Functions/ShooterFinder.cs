using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;
using WPILib.Interfaces;
using CoconutsFrc2017.Vision.PixyLibs;
using ChadDotNet;
using WPILib.SmartDashboard;

namespace CoconutsFrc2017.Functions
{
    class ShooterFinder
    {
        public void Run()
        {

        }
    }

    /// <summary>
    /// Navigates the robot to be positioned with an exact distance from the wall.
    /// </summary>
    public class CamForwardPID : GenericPID
    {
        /// <summary>
        /// Creates a new instance of the CamForwardPID class using the supplied PIDF values.
        /// </summary>
        /// <param name="kP">Proportional gain.</param>
        /// <param name="kI">Integral gain.</param>
        /// <param name="kD">Derivative gain.</param>
        /// <param name="kF">Filter gain.</param>
        public CamForwardPID(double kP, double kI, double kD, double kF) : base(kP, kI, kD, kF)
        {
            pidController.SetInputRange(0, 479f);
            pidController.SetOutputRange(-1.0f, 1.0f);

            pidController.SetAbsoluteTolerance(0);
        }

        public override PIDSourceType PIDSourceType { get; set; } = PIDSourceType.Displacement;

        public override void PidWrite(double value)
        {
            if (CamData.error == true)
                pidController.Disable();
            RobotMap.DriveTrain.SetLeftRightMotorOutputs(value, value);
        }

        public override double PidGet()
        {
            try
            {
                int x = PixyHandler.GetBlocks(2, CamData.blocks);
                return CamData.blocks.getitem(0).y;
            }
            catch (Exception)
            {
                SmartConsole.PrintInfo("Fatal error when using the Pixy in CamForwardPID.cs");
            }
            CamData.error = true;
            return 0;
        }
    }

    /// <summary>
    /// Generates the PID controller for the shooter's desired position using feedback from the Pixy.
    /// </summary>
    public class ShooterPosPID : GenericPID
    {
        /// <summary>
        /// Creates a new instance of the ShooterPosPID class using the supplied PIDF values.
        /// </summary>
        /// <param name="kP">Proportional gain.</param>
        /// <param name="kI">Integral gain.</param>
        /// <param name="kD">Derivative gain.</param>
        /// <param name="kF">Filter gain.</param>
        public ShooterPosPID(double kP, double kI, double kD, double kF) : base(kP, kI, kD, kF)
        {
            pidController.SetInputRange  (0 , 639f);    // Range of camera.
            pidController.SetOutputRange (-1.0f, 1.0f); // Range of encoders. CALIBRATE ME!

            pidController.SetAbsoluteTolerance(0);
        }

        public override PIDSourceType PIDSourceType { get; set; }

        public override void PidWrite(double value)
        {
            if (CamData.error == true)
                pidController.Disable();
            RobotMap.Shooter_Pivot.Set(value);
        }

        public override double PidGet()
        {
            try
            {
                int x = PixyHandler.GetBlocks(2, CamData.blocks);
                return CamData.blocks.getitem(0).y;
            }
            catch (Exception)
            {
                SmartConsole.PrintInfo("Fatal error when using the Pixy in CamForwardPID.cs");
            }
            CamData.error = true;
            return 0;
        }
    }

    /// <summary>
    /// Abstract class defining the components of a PID controller.
    /// </summary>
    public abstract class GenericPID : IPIDOutput, IPIDSource
    {
        public PIDController pidController;

        public abstract PIDSourceType PIDSourceType { get; set; }

        public GenericPID(double kP, double kI, double kD, double kF)
        {
            pidController = new PIDController(kP, kI, kD, kF, this, this);
        }

        public abstract double PidGet();

        public abstract void PidWrite(double value);

        public bool OnTarget()
        {
            SmartDashboard.PutBoolean(this.GetType().Name.ToString() + "OnTarget", pidController.OnTarget());
            return pidController.OnTarget();
        }
    }

    /// <summary>
    /// Class for containing camera data.
    /// </summary>
    public class CamData
    {
        /// <summary>
        /// Boolean whether or not the Pixy had an error initializing.
        /// False indicates that everything is operational, true means there was an error.
        /// </summary>
        public static bool error = false;

        /// <summary>
        /// Array for hold
        /// </summary>
        public static BlockArray blocks = new BlockArray(2);
    }
}