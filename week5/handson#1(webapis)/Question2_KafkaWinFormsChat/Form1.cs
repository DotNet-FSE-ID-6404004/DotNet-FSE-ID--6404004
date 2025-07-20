using System;
using System.Windows.Forms;

namespace KafkaChatWinForms
{
    public partial class Form1 : Form
    {
        private KafkaProducerConsumer _kafka;

        public Form1()
        {
            InitializeComponent();
            _kafka = new KafkaProducerConsumer();
            _kafka.StartConsumer(AppendMessage);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                await _kafka.SendMessageAsync(txtMessage.Text);
                txtMessage.Clear();
            }
        }

        private void AppendMessage(string msg)
        {
            if (txtChat.InvokeRequired)
            {
                txtChat.Invoke(new Action(() => txtChat.AppendText($"{msg}{Environment.NewLine}")));
            }
            else
            {
                txtChat.AppendText($"{msg}{Environment.NewLine}");
            }
        }
    }
}

