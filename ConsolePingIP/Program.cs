using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePingIP
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 沒有 port的ping IP
        /// </summary>
        /// <param name="ip"></param>
        public void PingIP(string ip)
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ip, 2000);//第一個引數為ip地址
            if (reply.Status == IPStatus.Success)
            {
                // 連線成功
            }
            else
            {
                // 連線失敗
            }
        }

        /// <summary>
        /// 有Port 的ping IP
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void PingIPPort(string ip , int port)
        {
            using (TcpClient tcpClient = new TcpClient(ip, port))
            {
                if (tcpClient.Connected)
                {
                    // 連線成功
                }
                else
                {
                   // 連線失敗
                }
            }
        }
    }
}
