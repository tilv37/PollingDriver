using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动轮询问答程序");
            ChannelClass newChannel=new ChannelClass();

            newChannel.DoWork();
        }
    }
}
