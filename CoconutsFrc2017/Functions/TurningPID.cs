using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;
using WPILib.Interfaces;

namespace CoconutsFrc2017.Functions
{
    public class TurningPID : IPIDOutput, IDataSource
    {
        public PIDController Controller;

        public TurningPID(double kp, double ki, double kd, double kf)
        {
            try
            {
                RobotMap.NavX.PIDSourceType = PIDSourceType.Displacement;
                Controller = new PIDController(kp, ki, kd, kf, RobotMap.NavX, this);

                Controller.SetInputRange(-180f, 180f);
                Controller.SetOutputRange(-0.45, 0.45);
                Controller.SetAbsoluteTolerance(10);
            }
            catch (Exception ex) { DriverStation.ReportError(ex.Message, true); }
        }

        public double GetData()
        {
            return RobotMap.NavX.GetYaw();
        }

        public void PidWrite(double value)
        {
            RobotMap.DriveTrain.SetLeftRightMotorOutputs(value, -value);
        }
    }

    public static class PIDFValues
    {
        public static double kP = 0.13;
        public static double kI = 0.0;
        public static double kD = 0.0;
        public static double kF = 0.0;
    }
}
