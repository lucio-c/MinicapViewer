using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Device;

namespace MiniTouch
{
    public class MiniTouchStream
    {
        //定义IP和监听的端口
        private String IP = "127.0.0.1";
        private int PORT = 1111;
        private Socket socket;
        private Banner banner = new Banner();
        private AndroidDevice device;

        public Banner Banner
        {
            get
            {
                return banner;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="scale">界面的显示比例</param>
        public MiniTouchStream(AndroidDevice device)
        {
            this.device = device;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse(IP), PORT));
            
            ParseBanner(socket);
        }
        
        /// <summary>
        /// 首次接收minitouh的banner信息
        /// </summary>
        /// <param name="socket"></param>
        private void ParseBanner(Socket socket)
        {
            byte[] chunk = new byte[64];
            socket.Receive(chunk);
            string[] result = Encoding.Default.GetString(chunk).Split(new char[2] { '\n', ' ' }).ToArray();
            //读取banner数据
            banner.Version = Convert.ToInt32(result[1]);
            banner.MaxContacts = Convert.ToInt32(result[3]);
            banner.MaxX = Convert.ToInt32(result[4]);
            banner.MaxY = Convert.ToInt32(result[5]);
            banner.MaxPressure = Convert.ToInt32(result[6]);
            banner.Pid = Convert.ToInt32(result[8]);
            //换算真实设备和minitouch识别到支持的百分比
            banner.PercentX = (double)device.Width / banner.MaxX;
            banner.PercentY = (double)device.Height / banner.MaxY;
        }

        /// <summary>
        /// 用于执行按下操作
        /// </summary>
        /// <param name="downpoint">按下的坐标值(此处为在本地显示的图像坐标点)</param>
        public void TouchDown(Point downpoint)
        {
            //转换为设备的真实坐标
            Point realpoint = PointConvert(downpoint);
            //通过minitouch命令执行点击;传递的文本'd'为点击命令，0为触摸点索引，X Y 为具体的坐标值，50为压力值，注意必须以\n结尾，否则无法触发动作
            ExecuteTouch(string.Format("d 0 {0} {1} 50\n", realpoint.X.ToString(), realpoint.Y.ToString()));
        }

        public void TouchUp()
        {
            //松开触摸点
            ExecuteTouch(string.Format("u 0\n"));
        }

        public void TouchMove(Point movepoint)
        {
            //转换为设备的真实坐标
            Point realpoint = PointConvert(movepoint);
            //通过minitouch命令执行划动;传递的文本'd'为划动命令，0为触摸点索引，X Y 为要滑动到的坐标值，50为压力值，注意必须以\n结尾，否则无法触发动作
            ExecuteTouch(string.Format("m 0 {0} {1} 50\n", realpoint.X.ToString(), realpoint.Y.ToString()));
        }

        /// <summary>
        /// 发送定义好的触摸动作命令进行动作执行
        /// </summary>
        /// <param name="touchcommand">minitouch触摸命令</param>
        public void ExecuteTouch(string touchcommand)
        {
            //将动作数据转换为socket要提交的byte数据
            byte[] inbuff = Encoding.ASCII.GetBytes(touchcommand);
            //发送socket数据
            socket.Send(inbuff);
            //提交触摸动作的命令
            string ccommand = "c\n";
            inbuff = Encoding.ASCII.GetBytes(ccommand);
            //发送socket数据确认触摸动作的执行
            socket.Send(inbuff);   
        }

        /// <summary>
        /// 设备真实坐标转换
        /// </summary>
        /// <param name="point">本地的图像操作坐标</param>
        /// <returns></returns>
        private Point PointConvert(Point point)
        {
            //根据设备显示比例换算出设备真实坐标点
            Point realpoint = new Point((int)(point.X / banner.PercentX) * device.Scale, (int)(point.Y / banner.PercentY) * device.Scale);
            return realpoint;
        }
    }
}
