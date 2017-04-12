using ChadDotNet;
using System;
using static CoconutsFrc2017.RobotMap;

namespace CoconutsFrc2017
{
    public class TeleOp : OperationMode
    {

        protected override void Init()
        {
            RobotMap.TurnController.Controller.Disable();
            
            Left1.MaxOutputVoltage = 12.0f;
            Right1.MaxOutputVoltage = 12.0f;
            
        }

        private bool toggleshift  = true ;
        private bool togglepto = true;
        private bool started = false;
        private long time           ;
        private int  encoderTicks   ;

        protected override void Main()
        {
            while (true)
            {
                

                if (Custom_Board.GetRawAxis(2) > 0.1)
                {
                    Intake1.Set(-1);
                    Intake2.Set(1);
                }

                else if (DriveStick_Right.GetRawButton(3) || Custom_Board.GetRawAxis(3) > 0.1)
                {
                    Intake1.Set(1);
                    Intake2.Set(-1);
                }

                else
                {
                    Intake1.Set(0);
                    Intake2.Set(0);
                }

                if (Custom_Board.GetRawButton(3))
                {
                    if (started)
                    {
                        if ((Environment.TickCount - time) > 1000)
                        {
                            Agitator.Set(1);
                            IntakeSecondStage.Set(-1);
                        }
                    }

                    else
                    {
                        time = Environment.TickCount;
                        started = true;
                        Shooter.Set(.95);
                    }
                }

                else if (Custom_Board.GetRawButton(2))
                {
                    if (started)
                    {
                        if ((Environment.TickCount - time) > 1000)
                        {
                            Agitator.Set(-1);
                            IntakeSecondStage.Set(-1);
                        }
                    }

                    else
                    {
                        time = Environment.TickCount;
                        started = true;
                        Shooter.Set(.95);
                    }
                }

                else
                {
                    Shooter.Set(0);
                    Agitator.Set(0);
                    IntakeSecondStage.Set(0);
                    started = false;
                }

                if (DriveStick_Left.GetRawButton(1) || DriveStick_Right.GetRawButton(1))
                {
                    if (toggleshift)
                    {
                        Shifters.Set(!Shifters.Get());

                        toggleshift = false;
                        
                    }
                }

                else
                {
                    toggleshift = true;
                }

                if (DriveStick_Left.GetRawButton(6) && DriveStick_Right.GetRawButton(11))
                {
                    if (togglepto)
                    {
                        PTO.Set(!PTO.Get());

                        togglepto = false;

                    }
                }

                else
                {
                    togglepto = true;
                }

                if (PTO.Get())
                {
                    if (DriveStick_Right.GetRawAxis(1) >= 0) DriveTrain.StopMotor();
                    else DriveTrain.Move(DriveStick_Right.GetRawAxis(1), DriveStick_Right.GetRawAxis(1));
                }
                else
                {
                    DriveTrain.Move(-DriveStick_Left.GetRawAxis(1), -DriveStick_Right.GetRawAxis(1));
                }

                if (Custom_Board.GetRawButton(4)) GearSlot.Set(true);
                else GearSlot.Set(false);

                //if (DriveStick_Left.GetRawAxis(2) > 0.1) PTO.Set(true);
                //else PTO.Set(false);

                // Set the shooter pivot to a specific point based on the joysticks.
                //TurntableController.Controller.Setpoint = ((encoderTicks + Custom_Board.GetRawAxis(4)) / 2);
                Shooter_Pivot.Set(.5 * Custom_Board.GetRawAxis(4));

                Snooze(10);
            }
        }

        protected override void End()
        {
            Stop();
        }
    }
}