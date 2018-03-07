using Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinicapViewer
{
    public partial class ConfigForm : Form
    {
        private int scale;
        private int orien;
        private AndroidDevice device;

        public ConfigForm()
        {
            InitializeComponent();
            device = new AndroidDevice();            
        }

        /// <summary>
        /// 根据配置设置设备显示比例和方向后显示主窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter_btn_Click(object sender, EventArgs e)
        {
            GetConfig();
            device.Scale = scale;
            device.Orientation = orien;
            //启动minicap监听
            Thread minicaptask = new Thread(device.StartMinicapServer);
            minicaptask.Start();
            //Thread.Sleep(1000);
            //启动minitouch监听
            Thread minitouchtask = new Thread(device.StartMiniTouchServer);
            minitouchtask.Start();
            Thread.Sleep(1000);
            //显示主窗体
            MainForm mform = new MainForm(device);
            this.Hide();
            mform.ShowDialog();            
        }


        /// <summary>
        /// 获取RadioButton的配置
        /// </summary>
        private void GetConfig()
        {   
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control button in control.Controls)
                    {
                        RadioButton rb = button as RadioButton;
                        if (rb != null && rb.Checked == true)
                        {
                            switch (rb.Text)
                            {
                                case "1：4":
                                    scale = 4;
                                    break;
                                case "1：3":
                                    scale = 3;
                                    break;
                                case "1：2":
                                    scale = 2;
                                    break;
                                case "1：1":
                                    scale = 1;
                                    break;
                                case "0°":
                                    orien = 0;
                                    break;
                                case "90°":
                                    orien = 90;
                                    break;    
                            }
                        }                        
                    }                    
                }
            }
        }
    }
}
