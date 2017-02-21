using System;
using System.Diagnostics;

namespace AS2_Tracker
{
    /*
    TODO:
    Convert to non-static class
    Cleanup 'parent' situation
    */

    public static class ProcessHandler
    {
        static MainForm parent;
        static bool processRunning;
		static bool hasExited;
        static Process audiosurf;

        /// <summary>
        /// Monitors the audiosurf process
        /// </summary>
        public static void CheckProcess()
        {
			if (!hasExited && audiosurf != null && audiosurf.HasExited) {
				audiosurf_Exited (null, null);
			} else {
				if (processRunning)
					return;
			}
				
			var processes = Process.GetProcessesByName("Audiosurf2.x86_64");
			if (processes.Length == 0) return; // Don't continue if it's not running
			audiosurf = processes[0];

			//audiosurf.EnableRaisingEvents = true;
			//audiosurf.Exited += new EventHandler(audiosurf_Exited);
			processRunning = true;
			hasExited = false;
            parent.SetLabelStatus(ProcessStatus()); // Set the label to the process status
                
            
        }

        //Handle Exited event
        static void audiosurf_Exited(object sender, System.EventArgs e)
        {
            processRunning = false;
			hasExited = true;

            parent.SetLabelStatus(ProcessStatus()); // Set the label to the process status

            string[] files = { Properties.Settings.Default.outputPath };
            SongUtil.LoadSongList(parent, files);

            //Console.WriteLine("Audiosurf EXITED.");
        }

        public static bool IsProcessRunning()
        {
            return processRunning;
        }

        public static string ProcessStatus()
        {
            string running;
            if (processRunning)
                running = "Audiosurf is running.";
            else
                running = "Audiosurf is not running.";

            return running;
        }

        /*
        Handle process timer
        */
        static System.Timers.Timer processTimer;
        public static void StartTimer(MainForm _parent)
        {
            parent = _parent;

            // Create a timer with a two second interval.
            processTimer = new System.Timers.Timer(2000);

            // Hook up the Elapsed event for the timer. 
            processTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            processTimer.AutoReset = true;

            // Start the timer
            processTimer.Enabled = true;

            GC.KeepAlive(processTimer);
        }

        static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            CheckProcess();
        }
    }
}
