using ChadDotNet;

namespace CoconutsFrc2017
{
    public class Auto : OperationMode
    {
        Handler AutoHandler;
        protected override void Init()
        {
            AutoHandler = new Handler();
        }

        protected override void Main()
        {
            AutoHandler.RunAuto(Handler.AutoPosition.Position1);
        }

        protected override void End()
        {
            
        }
    }
}