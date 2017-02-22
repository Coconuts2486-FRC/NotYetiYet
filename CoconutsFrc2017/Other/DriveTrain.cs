using System;
using WPILib;
using WPILib.Interfaces;

namespace CoconutsFrc2017
{
    public class DriveTrainObject : RobotDrive
    {
        public DriveTrainObject(ISpeedController frontLeftMotor, ISpeedController rearLeftMotor, ISpeedController frontRightMotor, ISpeedController rearRightMotor)
            : base(frontLeftMotor, rearLeftMotor, frontRightMotor, rearRightMotor) { }

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
    }
}
