namespace KafkaChatWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtChat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 310);
            this.txtMessage.Size = new System.Drawing.Size(400, 23);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(418, 310);
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(12, 12);
            this.txtChat.Multiline = true;
            this.txtChat.ScrollBars = ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(481, 292);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(505, 345);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Name = "Form1";
            this.Text = "Kafka Chat App";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
