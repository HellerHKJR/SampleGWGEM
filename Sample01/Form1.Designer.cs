namespace Sample01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LockStateGroupBox = new System.Windows.Forms.GroupBox();
            this.LockStateLabel = new System.Windows.Forms.Label();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.UnlockButton = new System.Windows.Forms.Button();
            this.LockButton = new System.Windows.Forms.Button();
            this.TerminalMessageListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LinkStateLabel = new System.Windows.Forms.Label();
            this.CommEnabledButton = new System.Windows.Forms.Button();
            this.CommDisabledButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ControlStateLabel = new System.Windows.Forms.Label();
            this.OnlineRemoteButton = new System.Windows.Forms.Button();
            this.OnlineLocalButton = new System.Windows.Forms.Button();
            this.OfflineButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LockStateGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LockStateGroupBox
            // 
            this.LockStateGroupBox.Controls.Add(this.LockStateLabel);
            this.LockStateGroupBox.Controls.Add(this.ChangePasswordButton);
            this.LockStateGroupBox.Controls.Add(this.UnlockButton);
            this.LockStateGroupBox.Controls.Add(this.LockButton);
            this.LockStateGroupBox.Location = new System.Drawing.Point(12, 240);
            this.LockStateGroupBox.Name = "LockStateGroupBox";
            this.LockStateGroupBox.Size = new System.Drawing.Size(318, 75);
            this.LockStateGroupBox.TabIndex = 18;
            this.LockStateGroupBox.TabStop = false;
            // 
            // LockStateLabel
            // 
            this.LockStateLabel.AutoSize = true;
            this.LockStateLabel.Location = new System.Drawing.Point(7, 52);
            this.LockStateLabel.Name = "LockStateLabel";
            this.LockStateLabel.Size = new System.Drawing.Size(84, 13);
            this.LockStateLabel.TabIndex = 8;
            this.LockStateLabel.Text = "State: Unlocked";
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.Enabled = false;
            this.ChangePasswordButton.Location = new System.Drawing.Point(168, 42);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(141, 23);
            this.ChangePasswordButton.TabIndex = 7;
            this.ChangePasswordButton.Text = "Change Password";
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            // 
            // UnlockButton
            // 
            this.UnlockButton.Enabled = false;
            this.UnlockButton.Location = new System.Drawing.Point(168, 13);
            this.UnlockButton.Name = "UnlockButton";
            this.UnlockButton.Size = new System.Drawing.Size(141, 23);
            this.UnlockButton.TabIndex = 6;
            this.UnlockButton.Text = "Unlock";
            this.UnlockButton.UseVisualStyleBackColor = true;
            // 
            // LockButton
            // 
            this.LockButton.Enabled = false;
            this.LockButton.Location = new System.Drawing.Point(6, 13);
            this.LockButton.Name = "LockButton";
            this.LockButton.Size = new System.Drawing.Size(141, 23);
            this.LockButton.TabIndex = 5;
            this.LockButton.Text = "Lock";
            this.LockButton.UseVisualStyleBackColor = true;
            // 
            // TerminalMessageListBox
            // 
            this.TerminalMessageListBox.FormattingEnabled = true;
            this.TerminalMessageListBox.Location = new System.Drawing.Point(12, 152);
            this.TerminalMessageListBox.Name = "TerminalMessageListBox";
            this.TerminalMessageListBox.Size = new System.Drawing.Size(318, 82);
            this.TerminalMessageListBox.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LinkStateLabel);
            this.groupBox2.Controls.Add(this.CommEnabledButton);
            this.groupBox2.Controls.Add(this.CommDisabledButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 98);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Host Communications";
            // 
            // LinkStateLabel
            // 
            this.LinkStateLabel.AutoSize = true;
            this.LinkStateLabel.Location = new System.Drawing.Point(7, 78);
            this.LinkStateLabel.Name = "LinkStateLabel";
            this.LinkStateLabel.Size = new System.Drawing.Size(79, 13);
            this.LinkStateLabel.TabIndex = 4;
            this.LinkStateLabel.Text = "State: Disabled";
            // 
            // CommEnabledButton
            // 
            this.CommEnabledButton.Location = new System.Drawing.Point(6, 19);
            this.CommEnabledButton.Name = "CommEnabledButton";
            this.CommEnabledButton.Size = new System.Drawing.Size(141, 23);
            this.CommEnabledButton.TabIndex = 4;
            this.CommEnabledButton.Text = "Enabled";
            this.CommEnabledButton.UseVisualStyleBackColor = true;
            // 
            // CommDisabledButton
            // 
            this.CommDisabledButton.Location = new System.Drawing.Point(6, 48);
            this.CommDisabledButton.Name = "CommDisabledButton";
            this.CommDisabledButton.Size = new System.Drawing.Size(141, 23);
            this.CommDisabledButton.TabIndex = 3;
            this.CommDisabledButton.Text = "Disabled";
            this.CommDisabledButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ControlStateLabel);
            this.groupBox1.Controls.Add(this.OnlineRemoteButton);
            this.groupBox1.Controls.Add(this.OnlineLocalButton);
            this.groupBox1.Controls.Add(this.OfflineButton);
            this.groupBox1.Location = new System.Drawing.Point(174, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 128);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control State";
            // 
            // ControlStateLabel
            // 
            this.ControlStateLabel.AutoSize = true;
            this.ControlStateLabel.Location = new System.Drawing.Point(7, 107);
            this.ControlStateLabel.Name = "ControlStateLabel";
            this.ControlStateLabel.Size = new System.Drawing.Size(68, 13);
            this.ControlStateLabel.TabIndex = 3;
            this.ControlStateLabel.Text = "State: Offline";
            // 
            // OnlineRemoteButton
            // 
            this.OnlineRemoteButton.Location = new System.Drawing.Point(6, 19);
            this.OnlineRemoteButton.Name = "OnlineRemoteButton";
            this.OnlineRemoteButton.Size = new System.Drawing.Size(141, 23);
            this.OnlineRemoteButton.TabIndex = 0;
            this.OnlineRemoteButton.Text = "Online Remote";
            this.OnlineRemoteButton.UseVisualStyleBackColor = true;
            // 
            // OnlineLocalButton
            // 
            this.OnlineLocalButton.Location = new System.Drawing.Point(6, 48);
            this.OnlineLocalButton.Name = "OnlineLocalButton";
            this.OnlineLocalButton.Size = new System.Drawing.Size(141, 23);
            this.OnlineLocalButton.TabIndex = 1;
            this.OnlineLocalButton.Text = "Online Local";
            this.OnlineLocalButton.UseVisualStyleBackColor = true;
            // 
            // OfflineButton
            // 
            this.OfflineButton.Location = new System.Drawing.Point(6, 77);
            this.OfflineButton.Name = "OfflineButton";
            this.OfflineButton.Size = new System.Drawing.Size(141, 23);
            this.OfflineButton.TabIndex = 2;
            this.OfflineButton.Text = "Offline";
            this.OfflineButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(18, 119);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(141, 23);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 331);
            this.Controls.Add(this.LockStateGroupBox);
            this.Controls.Add(this.TerminalMessageListBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.LockStateGroupBox.ResumeLayout(false);
            this.LockStateGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LockStateGroupBox;
        private System.Windows.Forms.Label LockStateLabel;
        private System.Windows.Forms.Button ChangePasswordButton;
        private System.Windows.Forms.Button UnlockButton;
        private System.Windows.Forms.Button LockButton;
        private System.Windows.Forms.ListBox TerminalMessageListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LinkStateLabel;
        private System.Windows.Forms.Button CommEnabledButton;
        private System.Windows.Forms.Button CommDisabledButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ControlStateLabel;
        private System.Windows.Forms.Button OnlineRemoteButton;
        private System.Windows.Forms.Button OnlineLocalButton;
        private System.Windows.Forms.Button OfflineButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

