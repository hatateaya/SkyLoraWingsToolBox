using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;

namespace LoraTool
{
    public class Serial
    {
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }
        private SerialPort serialPort;
        public Action<string> recieveAction;
        public Serial(string comName, int baud, Action<string> recieveAction)
        {
            serialPort = new SerialPort
            {
                PortName = comName,
                BaudRate = baud,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None
            };
            this.recieveAction = recieveAction;
            serialPort.Open();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(ReceiveData);

        }
        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort _SerialPort = (SerialPort)sender;
            int _bytesToRead = _SerialPort.BytesToRead;
            byte[] recvData = new byte[_bytesToRead];
            _SerialPort.Read(recvData, 0, _bytesToRead);
            string recvString = Encoding.UTF8.GetString(recvData);
            Debug.WriteLine("RECVSTRING：" + recvString);
            recieveAction.Invoke(recvString);
        }
        public void SendData(byte[] data)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Write(data, 0, data.Length);
            }
            else
            {
                throw new Exception();
            }
        }
        public void SendString(string str)
        {
            Debug.WriteLine("SENT:" + str);
            SendData(Encoding.UTF8.GetBytes(str));
        }
        public void Close()
        {
            serialPort.Close();
        }
    }
}
