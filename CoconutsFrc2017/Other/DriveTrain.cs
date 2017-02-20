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

        public void PidWrite(double value)
        {
            //TODO: smith fix
            throw new NotImplementedException();
        }
    }
}
