using ChadDotNet;

namespace CoconutsFrc2017
{
    public class Auto : OperationMode
    {
        protected override void Init()
        {
            Handler AutoHandler = new Handler();
            AutoHandler.RunAuto(Handler.AutoPosition.Disabled);
        }

        protected override void Main()
        {

        }

        protected override void End()
        {
            
        }
    }
}