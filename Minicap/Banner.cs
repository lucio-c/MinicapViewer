using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minicap
{
    public class Banner
    {
        private int version;
        private int length;
        private int pid;
        private int realwidth;
        private int realheight;
        private int virtualwidth;
        private int virtualheight;
        private int orientation;
        private int quirks;

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
        /// banner长度
        /// </summary>
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
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
        /// 设备的真实宽度
        /// </summary>
        public int RealWidth
        {
            get
            {
                return realwidth;
            }
            set
            {
                realwidth = value;
            }
        }

        /// <summary>
        /// 设备的真实高度
        /// </summary>
        public int RealHeight
        {
            get
            {
                return realheight;
            }
            set
            {
                realheight = value;
            }
        }

        /// <summary>
        /// 设备的虚拟宽度
        /// </summary>
        public int VirtualWidth
        {
            get
            {
                return virtualwidth;
            }
            set
            {
                virtualwidth = value;
            }
        }

        /// <summary>
        /// 设备的虚拟高度
        /// </summary>
        public int VirtualHeight
        {
            get
            {
                return virtualheight;
            }
            set
            {
                virtualheight = value;
            }
        }

        /// <summary>
        /// 设备方向
        /// </summary>
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

        /// <summary>
        /// 设备信息获取策略
        /// </summary>
        public int Quirks
        {
            get
            {
                return quirks;
            }
            set
            {
                quirks = value;
            }
        }

        public override String ToString()
        {
            return "Banner [version=" + version + ", length=" + length + ", pid="
                + pid + ", readWidth=" + realwidth + ", readHeight="
                + realheight + ", virtualWidth=" + virtualwidth
                + ", virtualHeight=" + virtualheight + ", orientation="
                + orientation + ", quirks=" + quirks + "]";
        }
    }
}
