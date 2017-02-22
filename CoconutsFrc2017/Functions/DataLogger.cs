using ChadDotNet;
using NetworkTables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPILib.SmartDashboard;

namespace CoconutsFrc2017.Functions
{
    public class DataLogger
    {
        private IDataSource source;
        private Thread collect_thread;
        private Stopwatch stopwatch;
        private TextWriter tw;

        /// <summary>
        /// Create a new instance of the Data Logger class.
        /// Use the specified
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        public DataLogger(IDataSource source, string dest)
        {
            this.source    = source;
            collect_thread = new Thread(Write);
            stopwatch      = new Stopwatch();
            tw             = new StreamWriter(dest);
        }

        public void ChangeDestination(string dest)
        {
            tw = new StreamWriter(dest);
        }

        private bool run;

        /// <summary>
        /// 
        /// </summary>
        public void WriteToFile()
        {
            run = true;
            if (collect_thread.ThreadState == System.Threading.ThreadState.Running)
                collect_thread.Start();
        }

        public void Stop()
        {
            run = false;
            collect_thread.Abort();
        }

        public void Write()
        {
            if(stopwatch.IsRunning)
                stopwatch.Start();

            TimeSpan ts;

            while (run)
            {
                ts = stopwatch.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", 
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                tw.WriteLine("{0},{1}", elapsedTime, source.GetData());
                NetworkTable table = NetworkTable.GetTable("cheetos");
                table.PutString("Data", string.Format("{0},{1}", elapsedTime, source.GetData()));
                SmartConsole.PrintInfo(string.Format("{0},{1}", elapsedTime, source.GetData()));
            }
        }
    }

    public interface IDataSource
    {
        /// <summary>
        /// GetData() is called when data is going to be retrieved.
        /// </summary>
        /// <returns>The data from the sensor.</returns>
        double GetData();
    }
}
