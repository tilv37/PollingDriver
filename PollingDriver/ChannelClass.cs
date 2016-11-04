using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace PollingDriver
{
    public class ChannelClass
    {

        private static TcpClient _tcpClient;
        private List<BaseMeterClass> _metersList=new List<BaseMeterClass>();
        public void DoWork()
        {
            this.InitComPara();
            this.CreatMeters();
            int k = 0;
            do
            {
                for (int i = 0; i < _metersList.Count; i++)
                {
                    BaseMeterClass baseMeter = _metersList[i];

                    baseMeter.HandleCommunication();
                }
                k++;
            } while (k<50);

        }

        private void InitComPara()
        {
            IPEndPoint ipEnd= new IPEndPoint(IPAddress.Parse("127.0.0.1"),2000);
            _tcpClient=new TcpClient(ipEnd);
        }

        private void CreatMeters()
        {
            int MeterCount = 7;//假设现在有7个DLT645规约的设备

            for (int i = 0; i < MeterCount; i++)
            {
                _metersList.Add(new Dlt645MeterClass());
            }
        }

        public static  TcpClient GeTcpClient()
        {
            if (_tcpClient != null)
            {
                return _tcpClient;
            }
            return null;
        }

    }
}
