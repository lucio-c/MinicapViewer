using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minicap;
using MiniTouch;
using System.IO;
using System.Threading;
using Device;

namespace MinicapViewer
{
    public partial class MainForm : Form
    {
        AndroidDevice device;
        MinicapStream minicap;
        MiniTouchStream minitouch;
        public MainForm(AndroidDevice device)
        {
            this.device = device;
            minicap = new MinicapStream();
            //minitouch = new MiniTouchStream(device);
            InitializeComponent();

            //判断设备方向来初始化界面SIZE
            if (device.Orientation == 90)
            {
                this.Width = device.VirtualHeight + 40;
                this.Height = device.VirtualWidth + 60;
                this.deviceImageBox.Width = device.VirtualHeight;
                this.deviceImageBox.Height = device.VirtualWidth;
            }
            else
            {
                this.Width = device.VirtualWidth + 40;
                this.Height = device.VirtualHeight + 60;
                this.deviceImageBox.Width = device.VirtualWidth;
                this.deviceImageBox.Height = device.VirtualHeight;
            } 
            this.DoubleBuffered = true;
            //注册UpdatePictureBox事件，用于监听图片流队列的读取方法以更新界面图像
            minicap.Update += new Minicap.MinicapEventHandler(UpdatePictureBox);
            Thread thread = new Thread(minicap.ReadImageStream);
            thread.Start();
        }

        int count = 0;
        /// <summary>
        /// 用于从minicap的图片数据队列中取出数据并显示到PictureBox中
        /// </summary>
        private void UpdatePictureBox()
        {
            Console.WriteLine(count++);
            deviceImageBox.Invalidate();
            byte [] buff = new byte[0];
            minicap.ImageByteQueue.TryDequeue(out buff);
            MemoryStream stream = new MemoryStream(buff);
            deviceImageBox.Image = Image.FromStream(stream);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void deviceImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //minitouch.TouchUp();
            }
        }

        private void deviceImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //minitouch.TouchDown(Rotate(e.Location));
            }
        }

        private void deviceImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //minitouch.TouchMove(Rotate(e.Location));
            }
        }


        /// <summary>
        /// 判断是否横屏决定是否需要进行坐标旋转
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private Point Rotate(Point point)
        {
            if(device.Orientation == 90)
            {
                point = new Point(device.VirtualWidth - point.Y, point.X);
            }
            return point;
        }
    }
}
