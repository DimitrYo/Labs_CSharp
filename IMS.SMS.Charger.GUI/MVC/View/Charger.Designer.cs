using System;
using IMS.SMS.GUI;

namespace IMS.SMS.Charger.GUI {
    partial class Charger {
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
            this.formattingComboBox = new System.Windows.Forms.ComboBox();
            this.SmsMessageBox = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePickerMin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMax = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chargeButton = new System.Windows.Forms.Button();
            this.batteryProgresBar = new IMS.SMS.Charger.GUI.BatteryProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // formattingComboBox
            // 
            this.formattingComboBox.FormattingEnabled = true;
            this.formattingComboBox.Items.AddRange(new object[] {
            "None",
            "Start with DateTime",
            "End with DateTime",
            "Lowercase",
            "Uppercase"});
            this.formattingComboBox.Location = new System.Drawing.Point(3, 56);
            this.formattingComboBox.Name = "formattingComboBox";
            this.formattingComboBox.Size = new System.Drawing.Size(173, 21);
            this.formattingComboBox.TabIndex = 3;
            this.formattingComboBox.SelectedIndexChanged += new System.EventHandler(this.FormattingComboBox_SelectedIndexChanged);
            // 
            // SmsMessageBox
            // 
            this.SmsMessageBox.Location = new System.Drawing.Point(30, 133);
            this.SmsMessageBox.Name = "SmsMessageBox";
            this.SmsMessageBox.ReadOnly = true;
            this.SmsMessageBox.Size = new System.Drawing.Size(620, 429);
            this.SmsMessageBox.TabIndex = 6;
            this.SmsMessageBox.Text = "";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(175, 21);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(3, 30);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(175, 20);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // userComboBox
            // 
            this.userComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Items.AddRange(new object[] {
            "DRYV",
            "SAN",
            "KUM",
            "DOM",
            "MEM",
            "REM",
            "GAP"});
            this.userComboBox.Location = new System.Drawing.Point(3, 3);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(173, 21);
            this.userComboBox.TabIndex = 4;
            this.userComboBox.Text = "Select User";
            this.userComboBox.TextChanged += new System.EventHandler(this.userComboBox_TextChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(182, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(173, 20);
            this.searchTextBox.TabIndex = 5;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // dateTimePickerMin
            // 
            this.dateTimePickerMin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerMin.Location = new System.Drawing.Point(3, 30);
            this.dateTimePickerMin.Name = "dateTimePickerMin";
            this.dateTimePickerMin.ShowCheckBox = true;
            this.dateTimePickerMin.ShowUpDown = true;
            this.dateTimePickerMin.Size = new System.Drawing.Size(173, 20);
            this.dateTimePickerMin.TabIndex = 6;
            this.dateTimePickerMin.ValueChanged += new System.EventHandler(this.dateTimePickerMin_ValueChanged);
            // 
            // dateTimePickerMax
            // 
            this.dateTimePickerMax.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerMax.Location = new System.Drawing.Point(182, 30);
            this.dateTimePickerMax.Name = "dateTimePickerMax";
            this.dateTimePickerMax.ShowCheckBox = true;
            this.dateTimePickerMax.ShowUpDown = true;
            this.dateTimePickerMax.Size = new System.Drawing.Size(173, 20);
            this.dateTimePickerMax.TabIndex = 7;
            this.dateTimePickerMax.ValueChanged += new System.EventHandler(this.dateTimePickerMax_ValueChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.userComboBox);
            this.flowLayoutPanel2.Controls.Add(this.searchTextBox);
            this.flowLayoutPanel2.Controls.Add(this.dateTimePickerMin);
            this.flowLayoutPanel2.Controls.Add(this.dateTimePickerMax);
            this.flowLayoutPanel2.Controls.Add(this.chargeButton);
            this.flowLayoutPanel2.Controls.Add(this.batteryProgresBar);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(387, 89);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // chargeButton
            // 
            this.chargeButton.Location = new System.Drawing.Point(3, 56);
            this.chargeButton.Name = "chargeButton";
            this.chargeButton.Size = new System.Drawing.Size(173, 23);
            this.chargeButton.TabIndex = 9;
            this.chargeButton.Text = "Connect charge";
            this.chargeButton.UseVisualStyleBackColor = true;
            this.chargeButton.Click += new System.EventHandler(this.chargeButton_Click);
            // 
            // batteryProgresBar
            // 
            this.batteryProgresBar.Location = new System.Drawing.Point(182, 56);
            this.batteryProgresBar.Name = "batteryProgresBar";
            this.batteryProgresBar.Size = new System.Drawing.Size(173, 23);
            this.batteryProgresBar.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(30, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMS Generation";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.startButton);
            this.flowLayoutPanel1.Controls.Add(this.stopButton);
            this.flowLayoutPanel1.Controls.Add(this.formattingComboBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(180, 77);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(242, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SMS FIltering";
            // 
            // Charger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 582);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SmsMessageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Charger";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmsFilter";
            this.Load += new System.EventHandler(this.SmsFilter_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ComboBox formattingComboBox;
        private System.Windows.Forms.RichTextBox SmsMessageBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePickerMin;
        private System.Windows.Forms.DateTimePicker dateTimePickerMax;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button chargeButton;
        private BatteryProgressBar batteryProgresBar;
    }
}