using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingDriver
{
    /// <summary>
    /// 这个就是DLT645规约类，在这里实现报文的构造方法抽象，校验函数等等规约强相关的东西
    /// </summary>
    class Dlt645ProtocolClass
    {
        public void Encode()
        {
            Console.WriteLine("完成DLT645 XXXX报文的构造");
        }

        public void DeCode()
        {
            Console.WriteLine("进行DLT645 XXXX类型报文的解析");
        }
    }
}
