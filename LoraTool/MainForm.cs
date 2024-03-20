using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LoraTool
{
    public partial class mainForm : Form
    {
        Serial serial;
        public mainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void mainForm_Load(object sender, System.EventArgs e)
        {
            SerialInitalize();
        }

        private void SerialInitalize()
        {
            foreach (var name in Serial.GetPortNames())
            {
                try
                {
                    var tmpSerial = new Serial(name, 9600, (str) => { });
                    tmpSerial.recieveAction = (str) =>
                    {
                        serial = tmpSerial;
                        SerialInitalized();
                    };
                    tmpSerial.SendData(new byte[] { 0x00, 0x00, 0x01 });
                    Program.SetTimeout(100, () =>
                    {
                        if (serial != tmpSerial)
                        {
                            tmpSerial.Close();
                        }
                    });
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            Program.SetTimeout(200, () =>
            {
                if (serial == null)
                {
                    MessageBox.Show("请插入SkyLoraWings模块，并且将MD0短接！","模块未成功连接",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            });
        }

        private void SerialInitalized()
        {
            serial.SendData(new byte[] { 0x80, 0x0b,0x01,0x68,0x65,0x69,0x62,0x61,0x69,0x6c,0x6f,0x76,0x65,0x73,0x61,0x77,0x61,0x6b,0x6f});
            statusLabel.Text = "状态：已连接";
            serial.recieveAction = (string str) => { serial.recieveAction = SerialRecieve; };
            ShowText("状态", "模块已连接。请解除短接MD0");
        }

        private void SerialRecieve(string str)
        {
            ShowText("收", str);
        }

        private void connectButton_Click(object sender, System.EventArgs e)
        {
            serial?.Close();
            statusLabel.Text = "状态：未连接";
            serial = null;
            ShowText("状态", "模块已断开。");
            SerialInitalize();
        }

        private void sendButton_Click(object sender, System.EventArgs e)
        {
            if (serial == null)
            {
                MessageBox.Show("模块未连接！", "无法发送信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                serial.SendString(sendTextBox.Text);
                ShowText("发", sendTextBox.Text);
                sendTextBox.Text = "";
            }
            catch
            {
                serial?.Close();
                statusLabel.Text = "状态：未连接";
                serial = null;
                ShowText("状态", "模块已断开。");
                MessageBox.Show("模块连接异常！", "发送信息失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click(new object(), new EventArgs());
            }
        }

        private void ShowText(string mode,string text)
        {
            textBox.AppendText($"{DateTime.Now.ToShortTimeString()} [{mode}] {text}\r\n");
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"您应当将SkyLoraWings模块插入计算机并在短接MD0时打开本程序。
在程序与模块已成功连接后，您应解除短接MD0。
您可以通过在文本框输入信息并回车来发送信息。
当您正确配置时，发出信息时模块会闪灯一次。
如果在您发出消息后又收到了截短的您发送的消息，这说明您没有解除短接MD0。","帮助",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
