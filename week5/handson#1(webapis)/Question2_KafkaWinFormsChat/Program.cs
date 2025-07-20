using KafkaChatWinForms;
using System;
using System.Windows.Forms;

namespace KafkaWinFormsChatApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
