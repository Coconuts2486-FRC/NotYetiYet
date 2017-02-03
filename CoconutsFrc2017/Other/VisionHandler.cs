using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoconutsFrc2017.Vision
{
    /// <summary>
    /// Class for running 
    /// </summary>
    class VisionHandler
    {
        /// <summary>
        /// Whether or not the program is currently aligning.
        /// </summary>
        public bool IsAligning { get; private set; }

        /// <summary>
        /// Finish me later.
        /// </summary>
        public bool StopAligningButton { private get; set; }

        public delegate void AlignDelegate();

        /// <summary>
        /// Event for aligning to the boiler.
        /// </summary>
        public event AlignDelegate AlignToBoiler;

        /// <summary>
        /// Event for aligning to the gear peg.
        /// </summary>
        public event AlignDelegate AlignToGear;

        public VisionHandler()
        {
            AlignToBoiler += Boiler;
            AlignToGear += Gear;
        }

        private void Boiler()
        {
            IsAligning = true;
            while (true)
            {
                // if(Joystick.get() == true)) break;
                // Align code goes here.
            }
            IsAligning = false;
        }

        private void Gear()
        {
            IsAligning = true;
            while (true)
            {
                // if(Joystick.get() == true)) break;
                // Align code goes here.
            }
            IsAligning = false;
        }
    }
}
