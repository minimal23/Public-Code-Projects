using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace dx_game_demo
{
    public class DxTimer
    {
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceFrequency(ref long Frequency);
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceCounter(ref long
        Count);
        private long LastTime = 0;
        private long CurrentTime = 0;
        private bool bTimerStart = true;
        private static long lTicksPerSecond = 0;
        private static bool bInitialized = false;
        public static long TicksPerSecond
        {
            get
            {
                return lTicksPerSecond;
            }
        }
        public void Init()
        {
            if (!QueryPerformanceFrequency(ref lTicksPerSecond))
                throw new Exception("Performance Counter is not Supported!");

            bInitialized = true;
        }
        public void markTime()
        {
            // Check if initialized
            if (!bInitialized)
            {
                throw new Exception("Timer not initialized!");
            }
            if (bTimerStart)
            {
                // Initialize time value
                QueryPerformanceCounter(ref LastTime);
                bTimerStart = false;
            }
        }
        public double msElapsed()
        {
            if (!bInitialized)
            {
                throw new Exception("Timer not initialized!");
            }
            QueryPerformanceCounter(ref CurrentTime);

            double dElapsedMilliseconds = ((double)(CurrentTime - LastTime) /
            (double)lTicksPerSecond) * 1000.0;
            return dElapsedMilliseconds;
        }
        public double secElapsed()
        {
            if (!bInitialized)
            {
                throw new Exception("Timer not initialized!");
            }
            QueryPerformanceCounter(ref CurrentTime);
            double dElapsedSeconds = (double)(CurrentTime - LastTime) /
            (double)lTicksPerSecond;
            return dElapsedSeconds;
        }
        public void resetTime()
        {
            bTimerStart = true;
        }
    }
}