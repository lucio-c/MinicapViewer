using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Device
{
    public class AndroidDevice
    {
        private int width;
        private int height;
        private int virtualwidth;
        private int virtualheight;
        private int virtualscale;
        private int orientation;
        private string abi;
        private string sdk;
        ADB adb = ADB.GetInstance();

        private string MINICAP_FILE_PATH;
        private string MINICAPSO_FILE_PATH;
        private string MINITOUCH_FILE_PATH;
        private string MINICAP_DEVICE_PATH = "/data/local/tmp";
        private string PUSH_COMMAND = "push";
        private string GET_SIZE_COMMAND = "shell dumpsys window windows | grep mScreenRect";
        private string GET_DEVICE_ABI_COMMAND = "shell getprop ro.product.cpu.abi";
        private string GET_DEVICE_SDK_COMMAND = "shell getprop ro.build.version.sdk";
        private int minicapport = 1313;
        private int minitouchport = 1111;

        public int Height
        {
            get
            {
                return height;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
        }

        public string Abi
        {
            get
            {
                return abi;
            }
        }
        public string SDK
        {
            get
            {
                return sdk;
            }
        }
        public int MINICAP_PORT
        {
            get
            {
                return minicapport;
            }
        }

        public int VirtualWidth
        {
            get
            {
                return virtualwidth;
            }
        }

        public int VirtualHeight
        {
            get
            {
                return virtualheight;
            }
        }

        public int Scale
        {
            get
            {
                return virtualscale;
            }
            set
            {
                virtualscale = value;
                this.GetScreenSize();
            }
        }

        public int Orientation
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
            }
        }

        public AndroidDevice()
        {
            this.InitDeviceInfo();
            this.PushFile();
        }

        private void PushFile()
        {
            PushMinicapFiles();
            PushMiniTouchFiles();
            PushMiniTouchFiles();
        }

        private void InitDeviceInfo()
        {
            abi = GetABI().Trim();
            sdk = GetSdkVersion().Trim();
            MINICAP_FILE_PATH = String.Format("Lib/minicap/bin/{0}/minicap", abi);
            MINICAPSO_FILE_PATH = String.Format("Lib/minicap/shared/android-{0}/{1}/minicap.so", sdk, abi);
            MINITOUCH_FILE_PATH = String.Format("Lib/minitouch/{0}/minitouch", abi);
        }

        public void pushFile(string localpath, string devicepath)
        {
            string command = string.Format("{0} {1} {2}", PUSH_COMMAND, localpath, devicepath);
            ExecuteAdbCommand(command);
        }

        public string ExecuteAdbCommand(string command)
        {
            return adb.RunCommand(command);
        }

        private void GetScreenSize()
        {
            string result = ExecuteAdbCommand(GET_SIZE_COMMAND);
            Match match = Regex.Match(result, @"\d{3,4}\,\d{3,4}");
            string size = match.Groups[0].Value;
            width = Convert.ToInt32(size.Split(',').ToArray()[0]);
            height = Convert.ToInt32(size.Split(',').ToArray()[1]);
            virtualwidth = width * (height / virtualscale) / height;
            virtualheight = height / virtualscale;
        }

        private string GetABI()
        {
            return ExecuteAdbCommand(GET_DEVICE_ABI_COMMAND);
        }

        private string GetSdkVersion()
        {
            return ExecuteAdbCommand(GET_DEVICE_SDK_COMMAND);
        }

        public void PushMinicapFiles()
        {
            pushFile(MINICAP_FILE_PATH, MINICAP_DEVICE_PATH);
            pushFile(MINICAPSO_FILE_PATH, MINICAP_DEVICE_PATH);
            string command = String.Format("shell chmod 777 {0}/minicap", MINICAP_DEVICE_PATH);
            ExecuteAdbCommand(command);
        }
        public void StartMinicapServer()
        {
            string command = string.Format("forward tcp:{0} localabstract:minicap", minicapport);
            ExecuteAdbCommand(command);
            command = string.Format("shell LD_LIBRARY_PATH={0} /data/local/tmp/minicap -P {1}x{2}@{3}x{4}/{5}", MINICAP_DEVICE_PATH, width, height, virtualwidth, virtualheight, orientation);
            ExecuteAdbCommand(command);
        }

        public void PushMiniTouchFiles()
        {
            pushFile(MINITOUCH_FILE_PATH, MINICAP_DEVICE_PATH);
            string command = String.Format("shell chmod 777 {0}/minitouch", MINICAP_DEVICE_PATH);
            ExecuteAdbCommand(command);
        }

        public void StartMiniTouchServer()
        {
            string command = string.Format("forward tcp:{0} localabstract:minitouch", minitouchport);
            ExecuteAdbCommand(command);
            command = string.Format("shell {0}/minitouch", MINICAP_DEVICE_PATH, width, height, virtualwidth, virtualheight, 0);
            ExecuteAdbCommand(command);
        }
    }
}
