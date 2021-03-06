﻿namespace IMS.Playback.GUI {
    partial class PlaySoundForm {
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
            this.ApplyButton = new System.Windows.Forms.Button();
            this.PlaybackComponents = new System.Windows.Forms.ListBox();
            this.MsgTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(356, 12);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(196, 60);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.applyClick);
            // 
            // PlaybackComponents
            // 
            this.PlaybackComponents.FormattingEnabled = true;
            this.PlaybackComponents.Location = new System.Drawing.Point(40, 12);
            this.PlaybackComponents.Name = "PlaybackComponents";
            this.PlaybackComponents.Size = new System.Drawing.Size(286, 199);
            this.PlaybackComponents.TabIndex = 1;
            // 
            // MsgTextBox
            // ;
            this.MsgTextBox.Location = new System.Drawing.Point(40, 234);
            this.MsgTextBox.Name = "MsgTextBox";
            this.MsgTextBox.Size = new System.Drawing.Size(512, 343);
            this.MsgTextBox.TabIndex = 2;
            this.MsgTextBox.Text = "";
            // 
            // PlaySoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 594);
            this.Controls.Add(this.MsgTextBox);
            this.Controls.Add(this.PlaybackComponents);
            this.Controls.Add(this.ApplyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaySoundForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForms PlaySound Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.ListBox PlaybackComponents;
        private System.Windows.Forms.RichTextBox MsgTextBox;
    }
}

