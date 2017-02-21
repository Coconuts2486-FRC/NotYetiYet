using System;
using WPILib;
using WPILib.Interfaces;

namespace CoconutsFrc2017.Other
{
    public class DriveTrain : RobotDrive, IPIDOutput
    {

        public DriveTrain(ISpeedController frontLeftMotor, ISpeedController rearLeftMotor,
                      ISpeedController frontRightMotor, ISpeedController rearRightMotor) : base(frontLeftMotor, rearLeftMotor, frontRightMotor, rearRightMotor)
        {
            
        }

        public void Move(double left, double right)
        {
            if (Lock)
            {

            }

            else
            {
                TankDrive(left, right);
            }
        }

        public bool Lock { set; get; } = false;

        public void PidWrite(double value)
        {
        }
    }
}
