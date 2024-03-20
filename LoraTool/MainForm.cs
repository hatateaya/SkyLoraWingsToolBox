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
            Program.SetTimeout(200, () =>
            {
                if (serial == null)
                {
                    MessageBox.Show("请插入SkyLoraWings模块，并且将MD0短接。");
                }
            });
        }

        private void SerialInitalized()
        {
            statusLabel.Text = "状态：已连接";
            textBox.AppendText("串口已连接\r\n");
            serial.recieveAction = SerialRecieve;
            textBox.AppendText("请解除短接MD0！\r\n");
        }

        private void SerialRecieve(string str)
        {
            textBox.AppendText(str + "\r\n");
        }

        private void connectButton_Click(object sender, System.EventArgs e)
        {
            SerialInitalize();
        }

        private void sendButton_Click(object sender, System.EventArgs e)
        {
            if (serial == null)
            {
                MessageBox.Show("串口未连接！");
                return;
            }
            serial.SendString(sendTextBox.Text);
            textBox.AppendText(sendTextBox.Text + "\r\n");
            sendTextBox.Text = "";
        }

        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click(new object(), new System.EventArgs());
            }
        }
    }
}
