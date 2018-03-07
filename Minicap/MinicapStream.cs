using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minicap
{
    /// <summary>
    /// 添加图片流接口
    /// </summary>
    public interface AddImageStream
    {
        void AddStream(byte[] buff);
    }

    public delegate void MinicapEventHandler();

    public class MinicapStream : AddImageStream
    {
        //定义UPDATE委托，用于写入图片流后通知其他监听器更新对象
        public event MinicapEventHandler Update;
        //用于存放图片流的队列
        private ConcurrentQueue<byte[]> bytequeue = new ConcurrentQueue<byte[]>();

        //定义IP和监听的端口
        private String IP = "127.0.0.1";
        private int PORT = 1313;

        //用于存放banner头信息
        private Banner banner = new Banner();
        private Socket socket;
        byte[] chunk = new byte[4096];
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public MinicapStream()
        {
            //启动socket连接
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse(IP), PORT));
        }

        /// <summary>
        /// 用于提取byte数组
        /// </summary>
        /// <param name="arr">源数组</param>
        /// <param name="start">起始位置</param>
        /// <param name="end">结束位置</param>
        /// <returns>提取后的数组</returns>
        private byte[] subByteArray(byte[] arr, int start, int end)
        {
            int len = end - start;
            byte[] newbyte = new byte[len];
            Buffer.BlockCopy(arr, start, newbyte, 0, len);
            return newbyte;
        }

        /// <summary>
        /// 存放由socket接收的图片字节信息数组的队列
        /// </summary>
        public ConcurrentQueue<byte[]> ImageByteQueue
        {
            get
            {
                return bytequeue;
            }
        }

        public Banner Banner
        {
            get
            {
                return banner;
            }
        }

        /// <summary>
        /// 读取图片流到队列
        /// </summary>
        public void ReadImageStream()
        {
            int reallen;
            int readBannerBytes = 0;
            int bannerLength = 2;
            int readFrameBytes = 0;
            int frameBodyLength = 0;
            byte[] frameBody = new byte[0];
            while ((reallen = socket.Receive(chunk)) != 0)
            {
                for (int cursor = 0, len = reallen; cursor < len; )
                {
                    //读取banner信息
                    if (readBannerBytes < bannerLength)
                    {
                        switch (readBannerBytes)
                        {
                            case 0:
                                banner.Version = chunk[cursor];
                                break;
                            case 1:
                                banner.Length = bannerLength = chunk[cursor];
                                break;
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                                banner.Pid += (chunk[cursor] << ((cursor - 2) * 8));
                                break;
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                banner.RealWidth += (chunk[cursor] << ((cursor - 6) * 8));
                                break;
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                                banner.RealHeight += (chunk[cursor] << ((cursor - 10) * 8));
                                break;
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                                banner.VirtualWidth += (chunk[cursor] << ((cursor - 14) * 8));
                                break;
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                                banner.VirtualHeight += (chunk[cursor] << ((cursor - 2) * 8));
                                break;
                            case 22:
                                banner.Orientation += chunk[cursor] * 90;
                                break;
                            case 23:
                                banner.Quirks = chunk[cursor];
                                break;
                        }
                        cursor += 1;
                        readBannerBytes += 1;
                    }
                    //读取每张图片的头4个字节(图片大小)
                    else if (readFrameBytes < 4)
                    {
                        frameBodyLength += (chunk[cursor] << (readFrameBytes * 8));
                        cursor += 1;
                        readFrameBytes += 1;
                    }
                    else
                    {
                        //读取图片内容
                        if (len - cursor >= frameBodyLength)
                        {
                            frameBody = frameBody.Concat(subByteArray(chunk, cursor, cursor + frameBodyLength)).ToArray();
                            AddStream(frameBody);
                            cursor += frameBodyLength;
                            frameBodyLength = readFrameBytes = 0;
                            frameBody = new byte[0];
                        }
                        else
                        {
                            frameBody = frameBody.Concat(subByteArray(chunk, cursor, len)).ToArray();
                            frameBodyLength -= len - cursor;
                            readFrameBytes += len - cursor;
                            cursor = len;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 写入图片流到队列，并通知监听器更新对象
        /// </summary>
        /// <param name="frameBody"></param>
        public void AddStream(byte[] frameBody)
        {
            bytequeue.Enqueue(frameBody);
            if (Update != null)
            {
                // 使用事件来通知给订阅者
                Update();
            }
        }
    }
}
