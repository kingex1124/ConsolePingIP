using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
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
        public void PingIPPort(string ip, int port)
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

        // 使用powerShell去pingIP 
        // 要先在專案檔中加入 	<Reference Include="System.Management.Automation" />

        /// <summary>
        /// 透過powershell Ping IP
        /// </summary>
        /// <param name="ip"></param>
        public void PingIPByPowerShell(string ip)
        {
            string powStr = string.Empty;

            try
            {
                using (PowerShell powershell = PowerShell.Create())
                {
                    string result = string.Empty;

                    powStr = string.Format("Test-NetConnection -ComputerName {0} ", ip);

                    powershell.AddScript(powStr);

                    var powerResult = powershell.Invoke();

                    foreach (PSObject resultItem in powerResult)
                        result = resultItem.Members["TcpTestSucceeded"].Value.ToString();

                    // powerShell錯誤訊息由此處處理
                    PSDataCollection<ErrorRecord> errors = powershell.Streams.Error;
                    if (errors != null && errors.Count > 0)
                    {
                        foreach (ErrorRecord err in errors)
                            Console.WriteLine("錯誤: {0}", err.ToString());
                    }

                    if (result == "False")
                    {
                        // 失敗處理
                    }
                    else
                    {
                        // 成功處理
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 透過powershell Ping IP 有Port
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void PingIPByPowerShell(string ip, int port)
        {
            string powStr = string.Empty;

            try
            {
                using (PowerShell powershell = PowerShell.Create())
                {
                    string result = string.Empty;

                    powStr = string.Format("Test-NetConnection -ComputerName {0} -Port {1}", ip, port);

                    powershell.AddScript(powStr);

                    var powerResult = powershell.Invoke();

                    foreach (PSObject resultItem in powerResult)
                        result = resultItem.Members["TcpTestSucceeded"].Value.ToString();

                    if (result == "False")
                    {
                        // 失敗處理
                    }
                    else
                    {
                        // 成功處理
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
