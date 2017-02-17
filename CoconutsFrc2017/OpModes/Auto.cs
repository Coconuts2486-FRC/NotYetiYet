using ChadDotNet.System;
using static CoconutsFrc2017.Core.RobotMap;

namespace CoconutsFrc2017.OpModes
{
    public class Auto : OperationMode
    {
        protected override void Init()
        {
            Autonomous.Handler AutoHandler = new Autonomous.Handler();
            AutoHandler.RunAuto(Autonomous.Handler.AutoPosition.Position1);
        }

        protected override void Main()
        {

        }

        protected override void End()
        {
            
        }
    }
}