using WPILib;
using CTRE;
using WPILib.Interfaces;
using System;
using WPILib.Extras.NavX;
using CoconutsFrc2017.Functions;
using WPILib.LiveWindow;

namespace CoconutsFrc2017
{
    public static class RobotMap
    {
        public static CANTalon Right1           { get { return can_01; } }
        public static CANTalon Right2           { get { return can_02; } }
        public static CANTalon Left1            { get { return can_03; } }
        public static CANTalon Left2            { get { return can_04; } }
        public static CANTalon Shooter_Pivot    { get { return can_05; } }
        public static CANTalon Intake1          { get { return can_06; } }
        public static CANTalon Intake2          { get { return can_07; } }
        public static CANTalon Shooter          { get { return can_08; } }
        public static CANTalon Adjetator        { get { return can_10; } }
        public static Solenoid Shifters         { get { return pcm_11_1; } }
        public static Solenoid PTO              { get { return pcm_11_2; } }
        public static Joystick DriveStick_Left  { get { return usb_0; } }
        public static Joystick DriveStick_Right { get { return usb_1; } }
        public static Joystick Custom_Board     { get { return usb_2; } }
        public static RobotDrive DriveTrain     { get { return sw_0; } }

        public static void Init()
        {
            can_01 = new CANTalon(1);
            can_02 = new CANTalon(2);
            can_03 = new CANTalon(3);
            can_04 = new CANTalon(4);
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
            sw_0 = new RobotDrive(Left1, Left2, Right1, Right2);

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
            
            Intake1.Inverted = true;

            CameraServer.Instance.StartAutomaticCapture();

            NavX = new AHRS(SPI.Port.MXP);
            TurnController = new TurningPID(PIDFValues.kP, PIDFValues.kI, PIDFValues.kD, PIDFValues.kF);
            TurnController.Controller.SetAbsoluteTolerance(0.02);

            LiveWindow.AddActuator("PID Turn Controller", "PID Output", TurnController.Controller);
        }

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

        private static RobotDrive sw_0;

        public static AHRS NavX;
        public static TurningPID TurnController;
    }
}
