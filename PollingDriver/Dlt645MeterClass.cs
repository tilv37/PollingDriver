using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PollingDriver
{
    class Dlt645MeterClass:BaseMeterClass
    {
        private Dlt645ProtocolClass dlt645;

        protected override void InitMeterCfg()
        {
            base.InitMeterCfg();
            Console.WriteLine("进行子类设备初始化");
            dlt645=new Dlt645ProtocolClass();
        }

        public override void HandleCommunication()
        {
            Console.WriteLine("进行子类设备的实际数据通信流程");

            //todo 这里就可以写报文构造啊，规约通信逻辑的代码了

            dlt645.Encode();
            Thread.Sleep(500);
            SendBuff(new byte[] {0x00,0x00},2);
            Thread.Sleep(500);
            //作为客户端，在工业通信里面，尤其是串口的通信，是需要非实时半双工工作的，所以要使用阻塞的方式去接受数据
            Recvbuff();
            Thread.Sleep(500);
            dlt645.DeCode();
            Thread.Sleep(500);
            this.EncodeJson();
            Thread.Sleep(500);
            this.PushAws();
            Thread.Sleep(500);

        }

        private void EncodeJson()
        {
            Console.WriteLine("构造json数据");
        }

        private void PushAws()
        {
            Console.WriteLine("向AWS推送数据");
        }

    }
}
