using System;
using CoconutsFrc2017.Functions;

namespace CoconutsFrc2017.OpModes.Autonomous.Modes
{
    class Red1 : IAuto
    {
        public void Run()
        {
            AutoFunctions.Drive(1.6418);       // Drive forward 1.6418 meters.
            AutoFunctions.TurnToAngle(-30f);   // Turn to -30 degrees.
            AutoFunctions.Drive(0.96);         // Drive forward 0.96 meters to align at gear peg.
            AutoFunctions.PlaceGear();         // Place the gear. This might incorporate vision. Currently does not.

            AutoFunctions.Drive(-0.96);        // Drive 0.96 meters backwards away from gear peg.
            AutoFunctions.TurnToAngle(0);      // Turn to 0 degrees.
            AutoFunctions.Drive(-0.7);         // Drive backwards -0.7 meters to clear airship for driving.
            AutoFunctions.TurnToAngle(133.74); // Turn to 133.74 degrees.
            AutoFunctions.Drive(6.5);          // Drive 6.5 meters forward to the boiler. NEEDS CLARIFICATION FROM LOGAN.
        }
    }

    class Red2 : IAuto
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    class Red3 : IAuto
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
