using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTouch
{
    public class Banner
    {
        private int version;
        private int maxcontacts;
        private int maxx;
        private int maxy;
        private int maxpressure;
        private int pid;
        private double percentx;
        private double percenty;

        /// <summary>
        /// 版本信息
        /// </summary>
        public int Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        /// <summary>
        /// 设备支持的最大触摸点数
        /// </summary>
        public int MaxContacts
        {
            get
            {
                return maxcontacts;
            }
            set
            {
                maxcontacts = value;
            }
        }

        /// <summary>
        /// 设备的最大宽度
        /// </summary>
        public int MaxX
        {
            get
            {
                return maxx;
            }
            set
            {
                maxx = value;
            }
        }

        /// <summary>
        /// 设备的最大高度
        /// </summary>
        public int MaxY
        {
            get
            {
                return maxy;
            }
            set
            {
                maxy = value;
            }
        }

        /// <summary>
        /// 设备的最大压力值
        /// </summary>
        public int MaxPressure
        {
            get
            {
                return maxpressure;
            }
            set
            {
                maxpressure = value;
            }
        }

        /// <summary>
        /// 进程ID
        /// </summary>
        public int Pid
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }


        /// <summary>
        ///真实设备宽度和minitouch显示的宽度的百分比
        /// </summary>
        public double PercentX
        {
            get
            {
                return percentx;
            }
            set
            {
                percentx = value;
            }
        }

        /// <summary>
        /// 真实设备高度和minitouch显示的高度的百分比
        /// </summary>
        public double PercentY
        {
            get
            {
                return percenty;
            }
            set
            {
                percenty = value;
            }
        }


        public override String ToString()
        {
            return "Banner [Version=" + version + ", Pid="
                + pid + ", MaxContacts=" + maxcontacts + ", Maxx="
                + maxx + ", MaxY=" + maxy
                + ", MaxPressure=" + maxpressure + "]";
        }
    }
}
