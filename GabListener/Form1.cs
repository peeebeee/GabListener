using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabListener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool _done = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
           
            int listenPort = 55600;
            _done = false;
            using (UdpClient listener = new UdpClient(listenPort))
            {
                IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
                while (!_done)
                {
                    byte[] receivedData = listener.Receive(ref listenEndPoint);

                    // richTextBox1.AppendText("Received broadcast message from client");

                    // richTextBox1.AppendText("Decoded data is:\r\n");
                    richTextBox1.AppendText(Encoding.ASCII.GetString(receivedData) + "\r\n");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _done = true;
        }
    }
}
