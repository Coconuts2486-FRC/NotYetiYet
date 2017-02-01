using System;
using ChadDotNet.Etc;

namespace CoconutsFrc2017.Core
{
    public class RobotConfig : Config
    {
        public override bool Log
        {
            get
            {
                return false;
            }
        }

        public override Type RobotClass
        {
            get
            {
                return typeof(Robot);
            }
        }

        public override bool ShadowRefrence
        {
            get
            {
                return false;
            }
        }

        public override string[] Splash
        {
            get
            {
                string[] splash = new string[7];
                splash[0] = "==============================";
                splash[1] = "Coconuts FRC 2017             ";
                splash[2] = "                              ";
                splash[3] = "Created by:                   ";
                splash[4] = "Marcus Eliason, Zach Smith,   ";
                splash[5] = "and Prescoot Mahon            ";
                splash[6] = "==============================";
                return splash;

            }
        }

        public override bool Verbose
        {
            get
            {
                return false;
            }
        }

        public override string Version
        {
            get
            {
                return "C# ChadDotNet & Robotdotnet";
            }
        }
    }
}