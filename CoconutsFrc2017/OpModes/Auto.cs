using ChadDotNet;
using static CoconutsFrc2017.RobotMap;

namespace CoconutsFrc2017
{
    public class Auto : OperationMode
    {
        protected override void Init()
        {
            Handler AutoHandler = new Handler();
            AutoHandler.RunAuto(Handler.AutoPosition.Position1);
        }

        protected override void Main()
        {

        }

        protected override void End()
        {
            
        }
    }
}