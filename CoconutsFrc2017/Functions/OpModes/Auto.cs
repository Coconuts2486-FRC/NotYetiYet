using ChadDotNet;

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

            //RobotMap.Right1.SetEncoderPostition(0);
            RobotMap.Right1.ReverseOutput(true);
            //RobotMap.Left1 .SetEncoderPostition(0);
            //RobotMap.Right1.Setpoint = 0;
            //RobotMap.Left1. Setpoint = 0;
            //RobotMap.Left1.ReverseOutput(true);
            RobotMap.NavX.Reset();
        }

        /// <summary>
        /// Runs the auto handler.
        /// </summary>
        protected override void Main()
        {
            // Runs the selected autonomous.
            AutoHandler.RunAuto(Handler.AutoPosition.Disabled);
        }

        protected override void End()
        {
            //RobotMap.Left1.ReverseOutput(false);
        }
    }
}