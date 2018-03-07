using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Device
{
    class ADB
    {
        private string adbproc = Environment.ExpandEnvironmentVariables("%ANDROID_HOME%") + "\\platform-tools\\adb.exe";
        ProcessStartInfo adbstart;
        private static ADB instance;
        private ADB()
        {
            RunCommand("kill-server");
            RunCommand("start-server");
        }

        public static ADB GetInstance()
        {
            if (instance == null)
            {
                instance = new ADB();
            }
            return instance;
        }

        public string RunCommand(string command)
        {
            adbstart = new ProcessStartInfo(adbproc);
            adbstart.Arguments = command;
            adbstart.CreateNoWindow = true;
            adbstart.RedirectStandardInput = true;
            adbstart.RedirectStandardOutput = true;
            adbstart.UseShellExecute = false;
            Process adbprocess = Process.Start(adbstart);
            StreamReader reader = adbprocess.StandardOutput;
            string result = reader.ReadToEnd();
            adbprocess.WaitForExit();
            reader.Close();
            adbprocess.Close();
            return result;
        }
    }
}
