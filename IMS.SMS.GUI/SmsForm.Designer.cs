using System;

namespace IMS.SMS.GUI {
    partial class SmsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.FormattingComboBox = new System.Windows.Forms.ComboBox();
            this.MessageBox = new System.Windows.Forms.RichTextBox();
            this.SMSProvider = new SmsProvider(new SmsProvider.SMSReceivedDelegate(OnSmsReceived));
            this.SuspendLayout();
            // 
            // FormattingComboBox
            // 
            this.FormattingComboBox.FormattingEnabled = true;
            this.FormattingComboBox.Items.AddRange(new object[] {
            "None",
            "Start with DateTime",
            "End with DateTime",
            "Lowercase",
            "Uppercase"});
            this.FormattingComboBox.Location = new System.Drawing.Point(30, 38);
            this.FormattingComboBox.Name = "FormattingComboBox";
            this.FormattingComboBox.Size = new System.Drawing.Size(236, 21);
            this.FormattingComboBox.TabIndex = 0;
            this.FormattingComboBox.Text = "Select Formatting";
            this.FormattingComboBox.SelectedIndexChanged += new System.EventHandler(this.FormattingComboBox_SelectedIndexChanged);
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(30, 79);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(451, 429);
            this.MessageBox.TabIndex = 1;
            this.MessageBox.Text = "";
            // 
            // SmsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 532);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.FormattingComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmsProvider";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox FormattingComboBox;
        private System.Windows.Forms.RichTextBox MessageBox;
        private SmsProvider SMSProvider;
        readonly object someEventLock = new object();


        public event Func<string, string> Formatter;

        private string FormatWithDateTimeOnStart(string message) {
            return  $"[{DateTime.Now}] {message}";
        }

        private string FormatWithDateTimeOnEnd(string message) {
            return  $"{message} [{DateTime.Now}] ";
        }

        private static string FormatUpperCase(string message) {
            return message.ToUpper();
        }

        private static string FormatLowerCase(string message) {
            return message.ToLower();
        }

        public void OnSmsReceived(string msg) {
            lock (someEventLock) {

                if (MessageBox.InvokeRequired == true) {
                    this?.BeginInvoke(new SmsProvider.SMSReceivedDelegate(OnSmsReceived), msg);
                }
                else {
                    msg = Formatter?.Invoke(msg) ?? msg;
                    MessageBox.AppendText($"{msg}{Environment.NewLine}");
                }
            }
        }
    }
}

