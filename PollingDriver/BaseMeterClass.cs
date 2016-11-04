using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace PollingDriver
{
    class BaseMeterClass
    {

        private TcpClient _TcpClient;
        private NetworkStream ns;

        public BaseMeterClass() 
        {
            InitMeterCfg();
        }
        /// <summary>
        /// 初始化设备对象，包括获取通信端口，及其他设备自身所需要的相关信息
        /// </summary>
        protected virtual void InitMeterCfg()
        {
           // _TcpClient = ChannelClass.GeTcpClient();
            //ns= _TcpClient.GetStream();

        }

        /// <summary>
        /// 主要通信处理逻辑入口
        /// </summary>
        public virtual void HandleCommunication()
        {
            
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="length"></param>
        protected void SendBuff(byte[] buf, int length)
        {
            //为方便实验进行调试输出

            Console.WriteLine("向设备发送请求数据");
            return;

            if (_TcpClient == null)
            {
                Console.WriteLine("当前为可用socket");
                return;
            }

            if (_TcpClient.Connected)
            {
                Console.WriteLine("当前未连接到远程主机");
                return;
            }

            Console.WriteLine("发送数据至客户端");
            ns.Write(buf,0,length);
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        protected byte[] Recvbuff()
        {
            //为方便实验进行调试输出

            Console.WriteLine("收到了设备回复的数据");
            return null;


            if (WaitForByte(1000))
            {
                long byteInBuff = ns.Length;
                List<byte> retBytesList=new List<byte>();
                do
                {
                    retBytesList.Add((byte)ns.ReadByte());
                    Thread.Sleep(50);//字节间接收间隔
                } while (retBytesList.Count>=byteInBuff);
                //这里1000是字节间接收的超时时间

                return retBytesList.ToArray();
            }
            return null;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout">接收超时时间,ms</param>
        /// <returns></returns>
        private bool WaitForByte(int timeout)
        {
            int sleepCount = 1;
            long bytesInBuffer =0;
            do
            {
                if (ns.DataAvailable)
                {
                    //确认收到了数据，并且获取缓冲区内的数据长度
                    bytesInBuffer = ns.Length;
                }
                sleepCount++;
                
                Thread.Sleep(50);

            } while ((50*sleepCount) < timeout);

            if (bytesInBuffer == 0)
            {
                Console.WriteLine("数据接收超时");
                return false;
            }

            return true;
        }
    }
}
